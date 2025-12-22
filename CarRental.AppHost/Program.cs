var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql")
    .WithEnvironment("MYSQL_ROOT_PASSWORD", "root123")
    .WithEnvironment("MYSQL_DATABASE", "CarRentalDb")
    .AddDatabase("CarRentalDb");

builder.AddProject<Projects.CarRental_Api>("carrental-api")
    .WithReference(mysql)
    .WaitFor(mysql);

builder.Build().Run();