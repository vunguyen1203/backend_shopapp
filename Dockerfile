FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

RUN apk add --no-cache icu-libs tzdata

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ=Asia/Bangkok

USER $APP_UID
WORKDIR /app
EXPOSE 8080	
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["backend_shopapp/backend_shopapp.csproj", "backend_shopapp/"]
RUN dotnet restore "./backend_shopapp/backend_shopapp.csproj"
COPY . .
WORKDIR "/src/backend_shopapp"
RUN dotnet build "./backend_shopapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./backend_shopapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend_shopapp.dll"]
