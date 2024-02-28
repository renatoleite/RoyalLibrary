# Clean Architecture - Royal Library - REST API 

This application was created to manage a libary, It's an application using .NET 7, Docker, and Docker-Composer

## Install

To run the application first is necessary to run the docker-compose command using a prompt command.

```bash
docker compose up -d
```

## Run the app

You can run the application through Visual Studio and the URL created by Docker

Docker application endpoint:

`http://localhost:8090/swagger/`

After execution it will be possible to use the application using `Swagger`

# Architecture

This application is built with clean architecture, it was created in a short time, so there are some improvements that can be made.

The app was built using the book domain as a base. There is an use cases to get the books and is using chain of responsability pattern to execute each operation.

The application has a database resiliency system using Polly, uses SQL Server and Dapper to communicate with the database.