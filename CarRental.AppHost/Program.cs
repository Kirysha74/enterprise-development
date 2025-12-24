using Aspire.Hosting;
using Aspire.Hosting.MySql;

var builder = DistributedApplication.CreateBuilder(args);

var kafkaTopic = "applications-topic";
var fetchMinBytes = "4096";
var kafkaProduceDelayMs = "1000";

var kafkaTopicParam = builder.AddParameter("KafkaTopic", kafkaTopic);
var produceDelayParam = builder.AddParameter("KafkaProduceDelayMs", kafkaProduceDelayMs);
var fetchMinBytesParam = builder.AddParameter("KafkaFetchMinBytes", fetchMinBytes);

var mysql = builder.AddMySql("mysql")
    .WithEnvironment("MYSQL_ROOT_HOST", "%")
    .WithVolume("mysql-data", "/var/lib/mysql")
    .WithImage("mysql", "8.0")
    .AddDatabase("CarRentalDb");

var kafka = builder.AddKafka("Kafka")
    .WithEnvironment("KafkaTopic", kafkaTopic)
    .WithEnvironment("KafkaProduceDelay", kafkaProduceDelayMs)
    .WithKafkaUI();


builder.AddProject<Projects.CarRental_Kafka>("KafkaProducer")
    .WithReference(kafka, "KafkaConnection")
    .WaitFor(kafka)
    .WithEnvironment("KafkaTopic", kafkaTopic)
    .WithEnvironment("KafkaProduceDelay", kafkaProduceDelayMs);

var api = builder.AddProject<Projects.CarRental_Api>("carrental-api")
    .WithReference(kafka, "KafkaConnection")
    .WithReference(mysql, "DefaultConnection")
    .WaitFor(mysql)
    .WaitFor(kafka)
    .WithEnvironment("KafkaTopic", kafkaTopic)
    .WithEnvironment("KafkaFetchMinBytes", fetchMinBytes);

builder.Configuration["ASPIRE_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS"] = "true";

builder.Build().Run();