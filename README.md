# Asp.net Core Web Api Backend Shopapp project

Hi there, I spent some time writing one backend RESTful api project for shop app online. This app was made for the sole purpose of study. 

## Technologories:

- Asp.Net core Web Api (.Net 8).
- SQL Server.
- Entity Framework core.
- Authentication and Authorization with jwt.
- Swagger.
- Docker.
- Payment method online VNpay.

## Config "appsettings.json":

cd ./backend_shopapp/backend_shopapp

![Alt text for screen readers](./appsettings.png)

##### Register merchant env test Vnpay at: https://sandbox.vnpayment.vn/devreg/

##### VNPay will send you the test configuration information via email.

![Alt text for screen readers](./info_config_vnpay.png)

"ReturnUrl": use localhost:5286 or localhost:7121 in env dev and use ip or domain public in env production
"TimeZoneId": use "Asia/Bangkok" with linux and "SE Asia Standard Time" with windows

Deploy:
Migration before run command.

- cd ./backend_shopapp
- docker build -t name_image .
- docker run -d --name name_container -p 8080:8080 -p 8081:8081 -v ./app/logs:/app/logs -v ./app/wwwroot:/app/wwwroot name_image

Docs api: Docker: "[your_domain]:8080/swagger".
