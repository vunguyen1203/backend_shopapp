# Asp.net Core Web Api Backend Shopapp project

Hi there, I spent some time writing one backend RESTful api project for shop app online. This app was made for the sole purpose of study.

## Technologories:

- Asp.Net core Web Api (.Net 8).
- SQL Server.
- Redis.
- Entity Framework core.
- Authentication and Authorization with jwt.
- Swagger.
- Docker.
- Payment method online: VNpay.

## Deploy:

- edit appsettings.json
- docker build -t name_image .
- docker run -d --name name_container -p 8080:8080 -v ./app/logs:/app/logs -v ./app/wwwroot:/app/wwwroot name_image
