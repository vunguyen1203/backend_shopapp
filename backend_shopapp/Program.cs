using backend_shopapp;
using backend_shopapp.Dtos.Brand;
using backend_shopapp.Dtos.Category;
using backend_shopapp.Dtos.Voucher;
using backend_shopapp.Exceptions;
using backend_shopapp.Interfaces;
using backend_shopapp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Formatting.Json;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token like: Bearer {your token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database")
));

builder.Services.AddSingleton<IConnectionMultiplexer>(options => 
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")
));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { message = "Unauthorized" });
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { message = "Forbidden" });
            }
        };
    });

builder.Services.AddAuthorization();

builder.Host.UseSerilog((context, config) =>
{
    config
        .WriteTo.Console().MinimumLevel.Information()
        .WriteTo.File(
            path: AppDomain.CurrentDomain.BaseDirectory + "logs/log-.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            formatter: new JsonFormatter()).MinimumLevel.Information();
});

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixedwindow", o =>
    {
        o.PermitLimit = 30;
        o.Window = TimeSpan.FromSeconds(60);
        o.QueueLimit = 0;
        o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsJsonAsync(new
        {
            message = "Too many requests"
        });
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy
            .WithOrigins()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddHostedService<ProductViewCountWorker>();

builder.Services.AddScoped<IService<CreateBrandRequest, UpdateBrandRequest, BrandResponse>, BrandService>();
builder.Services.AddScoped<IService<CreateCategoryRequest, UpdateCategoryRequest, CategoryResponse>, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IVariantService, VariantService>();
builder.Services.AddScoped<IVariantImageService, VariantImageService>();
builder.Services.AddScoped<IService<CreateVoucherRequest, UpdateVoucherRequest, VoucherResponse>, VoucherService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFeedBackService, FeedBackService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVnpayService, VnPayService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ISlugifyService, SlugifyService>();

var app = builder.Build();

app.UseRateLimiter();

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}



app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
