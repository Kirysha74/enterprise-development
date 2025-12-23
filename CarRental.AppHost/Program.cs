using Aspire.Hosting;
using Aspire.Hosting.MySql;

var builder = DistributedApplication.CreateBuilder(args);

// 1. MySQL
var mysql = builder.AddMySql("mysql")
    .WithEnvironment("MYSQL_ROOT_HOST", "%")
    .AddDatabase("CarRentalDb");

// 2. API (АБСОЛЮТНЫЙ ПУТЬ)
var apiPath = @"C:\Users\kaha2\source\repos\Kirysha74\enterprise-development\CarRental.Api\CarRental.Api.csproj";
var api = builder.AddProject("carrental-api", apiPath)
    .WithReference(mysql);

builder.Build().Run();