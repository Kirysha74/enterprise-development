using Aspire.Hosting;
using Aspire.Hosting.MySql;

var builder = DistributedApplication.CreateBuilder(args);


var mysql = builder.AddMySql("mysql")
    .WithEnvironment("MYSQL_ROOT_HOST", "%")
    .WithVolume("mysql-data", "/var/lib/mysql")
    .WithImage("mysql", "8.0")
    .AddDatabase("CarRentalDb");

var api = builder.AddProject<Projects.CarRental_Api>("carrental-api")
    .WithReference(mysql, "DefaultConnection")
    .WaitFor(mysql);

builder.Configuration["ASPIRE_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS"] = "true";

builder.Build().Run();