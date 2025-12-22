using CarRental.Application.Contracts;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Persistence;
using CarRental.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlApi = Path.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    c.IncludeXmlComments(xmlApi, includeControllerXmlComments: true);
});

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    ));

builder.Services.AddScoped<IRepository<Car>, DbRepository<Car>>();
builder.Services.AddScoped<IRepository<Client>, DbRepository<Client>>();
builder.Services.AddScoped<IRepository<CarModel>, DbRepository<CarModel>>();
builder.Services.AddScoped<IRepository<ModelGeneration>, DbRepository<ModelGeneration>>();
builder.Services.AddScoped<IRepository<Rental>, DbRepository<Rental>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    // Загружаем тестовые данные если таблицы пустые
    if (!db.CarModels.Any())
    {
        Console.WriteLine("Seeding database...");

        var testData = new CarRental.Domain.Data.TestData();

        // Добавляем в правильном порядке
        db.CarModels.AddRange(testData.CarModels);
        db.Clients.AddRange(testData.Clients);
        db.SaveChanges();

        // Обновляем связи
        foreach (var mg in testData.ModelGenerations)
        {
            mg.Model = db.CarModels.First(m => m.Id == mg.ModelId);
        }
        db.ModelGenerations.AddRange(testData.ModelGenerations);
        db.SaveChanges();

        foreach (var car in testData.Cars)
        {
            car.ModelGeneration = db.ModelGenerations.First(mg => mg.Id == car.ModelGenerationId);
        }
        db.Cars.AddRange(testData.Cars);
        db.SaveChanges();

        foreach (var rental in testData.Rentals)
        {
            rental.Car = db.Cars.First(c => c.Id == rental.CarId);
            rental.Client = db.Clients.First(c => c.Id == rental.ClientId);
        }
        db.Rentals.AddRange(testData.Rentals);
        db.SaveChanges();

        Console.WriteLine("Database seeded successfully!");
    }
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Rental API");
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapDefaultEndpoints();
app.MapControllers();

app.Run();