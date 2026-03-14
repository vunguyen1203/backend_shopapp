using backend_shopapp.Models;
using StackExchange.Redis;

namespace backend_shopapp
{
    public class ProductViewCountWorker : BackgroundService
    {
        private readonly IConnectionMultiplexer _conntection;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProductViewCountWorker(IConnectionMultiplexer conntection, IServiceScopeFactory scopeFactory)
        {
            _conntection = conntection;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cache = _conntection.GetDatabase();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);

                var server = _conntection.GetServer(_conntection.GetEndPoints()[0]);
                var keys = server.Keys(pattern: "product:view:*");

                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                foreach (var key in keys)
                {
                    var value = await cache.StringGetAsync(key);
                    if (!value.HasValue) continue;

                    string productId = key.ToString().Split(":")[2];

                    Product product = await db.Products.FindAsync(productId);
                    if (product != null)
                    {
                        product.View += (int)value;
                    }

                    //await db.KeyDeleteAsync($"product:{productId}");
                    await cache.KeyDeleteAsync($"product:view:{productId}");
                }
                await db.SaveChangesAsync();

                //await db.StringIncrementAsync("products:version");
            }
        }
    }
}
