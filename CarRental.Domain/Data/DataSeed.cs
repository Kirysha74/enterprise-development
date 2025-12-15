using CarRental.Domain.Models;

namespace CarRental.Domain.Data;

/// <summary>
/// Test data generator for car rental
/// </summary>
public class TestData
{
    /// <summary>
    /// List of car models
    /// </summary>
    public List<CarModel> CarModels { get; }

    /// <summary>
    /// List of clients
    /// </summary>
    public List<Client> Clients { get; }

    /// <summary>
    /// List of model generations
    /// </summary>
    public List<ModelGeneration> ModelGenerations { get; }

    /// <summary>
    /// List of cars
    /// </summary>
    public List<Car> Cars { get; }

    /// <summary>
    /// List of rentals
    /// </summary>
    public List<Rental> Rentals { get; }

    /// <summary>
    /// Constructor for data initialization
    /// </summary>
    public TestData()
    {
        CarModels = new()
        {
            new()
            {
                Id = 1,
                Name = "BMW 3 Series",
                DriveType = "RWD",
                SeatsCount = 5,
                BodyType = "Sedan",
                Class = "Premium"
            },
            new()
            {
                Id = 2,
                Name = "Ford Mustang",
                DriveType = "RWD",
                SeatsCount = 4,
                BodyType = "Coupe",
                Class = "Sports"
            },
            new()
            {
                Id = 3,
                Name = "Honda Civic",
                DriveType = "FWD",
                SeatsCount = 5,
                BodyType = "Sedan",
                Class = "Compact"
            },
            new()
            {
                Id = 4,
                Name = "Jeep Wrangler",
                DriveType = "4WD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Off-road"
            },
            new()
            {
                Id = 5,
                Name = "Porsche 911",
                DriveType = "RWD",
                SeatsCount = 4,
                BodyType = "Coupe",
                Class = "Luxury"
            },
            new()
            {
                Id = 6,
                Name = "Chevrolet Tahoe",
                DriveType = "AWD",
                SeatsCount = 8,
                BodyType = "SUV",
                Class = "Full-size"
            },
            new()
            {
                Id = 7,
                Name = "Lada Vesta",
                DriveType = "FWD",
                SeatsCount = 5,
                BodyType = "Sedan",
                Class = "Economy"
            },
            new()
            {
                Id = 8,
                Name = "Subaru Outback",
                DriveType = "AWD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Mid-size"
            },
            new()
            {
                Id = 9,
                Name = "GAZ Gazelle Next",
                DriveType = "RWD",
                SeatsCount = 3,
                BodyType = "Van",
                Class = "Commercial"
            },
            new()
            {
                Id = 10,
                Name = "Toyota Prius",
                DriveType = "FWD",
                SeatsCount = 5,
                BodyType = "Hatchback",
                Class = "Hybrid"
            },
            new()
            {
                Id = 11,
                Name = "UAZ Patriot",
                DriveType = "4WD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Off-road"
            },
            new()
            {
                Id = 12,
                Name = "Lexus RX",
                DriveType = "AWD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Premium"
            },
            new()
            {
                Id = 13,
                Name = "Range Rover Sport",
                DriveType = "AWD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Luxury"
            },
            new()
            {
                Id = 14,
                Name = "Audi A4",
                DriveType = "AWD",
                SeatsCount = 5,
                BodyType = "Sedan",
                Class = "Premium"
            },
            new()
            {
                Id = 15,
                Name = "Lada Niva Travel",
                DriveType = "4WD",
                SeatsCount = 5,
                BodyType = "SUV",
                Class = "Off-road"
            }
        };

        Clients = new()
        {
            new()
            {
                Id = 1,
                LicenseNumber = "2023-001",
                FullName = "Alexander Smirnov",
                BirthDate = new DateOnly(1988, 3, 15)
            },
            new()
            {
                Id = 2,
                LicenseNumber = "2022-045",
                FullName = "Marina Kovalenko",
                BirthDate = new DateOnly(1992, 7, 22)
            },
            new()
            {
                Id = 3,
                LicenseNumber = "2024-012",
                FullName = "Denis Popov",
                BirthDate = new DateOnly(1995, 11, 10)
            },
            new()
            {
                Id = 4,
                LicenseNumber = "2021-078",
                FullName = "Elena Vasnetsova",
                BirthDate = new DateOnly(1985, 5, 3)
            },
            new()
            {
                Id = 5,
                LicenseNumber = "2023-056",
                FullName = "Igor Kozlovsky",
                BirthDate = new DateOnly(1990, 9, 30)
            },
            new()
            {
                Id = 6,
                LicenseNumber = "2022-123",
                FullName = "Anna Orlova",
                BirthDate = new DateOnly(1993, 2, 14)
            },
            new()
            {
                Id = 7,
                LicenseNumber = "2024-034",
                FullName = "Artem Belov",
                BirthDate = new DateOnly(1987, 8, 18)
            },
            new()
            {
                Id = 8,
                LicenseNumber = "2021-099",
                FullName = "Sofia Grigorieva",
                BirthDate = new DateOnly(1994, 12, 25)
            },
            new()
            {
                Id = 9,
                LicenseNumber = "2023-087",
                FullName = "Pavel Melnikov",
                BirthDate = new DateOnly(1991, 6, 7)
            },
            new()
            {
                Id = 10,
                LicenseNumber = "2022-067",
                FullName = "Olga Zakharova",
                BirthDate = new DateOnly(1989, 4, 12)
            },
            new()
            {
                Id = 11,
                LicenseNumber = "2024-005",
                FullName = "Mikhail Tikhonov",
                BirthDate = new DateOnly(1996, 10, 28)
            },
            new()
            {
                Id = 12,
                LicenseNumber = "2021-112",
                FullName = "Ksenia Fedorova",
                BirthDate = new DateOnly(1986, 1, 19)
            },
            new()
            {
                Id = 13,
                LicenseNumber = "2023-092",
                FullName = "Roman Sokolov",
                BirthDate = new DateOnly(1997, 7, 3)
            },
            new()
            {
                Id = 14,
                LicenseNumber = "2022-031",
                FullName = "Tatiana Krylova",
                BirthDate = new DateOnly(1984, 3, 22)
            },
            new()
            {
                Id = 15,
                LicenseNumber = "2024-021",
                FullName = "Andrey Davydov",
                BirthDate = new DateOnly(1998, 11, 15)
            }
        };

        ModelGenerations = new()
        {
            new()
            {
                Id = 1,
                Year = 2023,
                EngineVolume = 2.0,
                Transmission = "AT",
                RentalPricePerHour = 2200,
                ModelId = 1,
                Model = CarModels[0]
            },
            new()
            {
                Id = 2,
                Year = 2022,
                EngineVolume = 5.0,
                Transmission = "AT",
                RentalPricePerHour = 5000,
                ModelId = 2,
                Model = CarModels[1]
            },
            new()
            {
                Id = 3,
                Year = 2024,
                EngineVolume = 1.5,
                Transmission = "CVT",
                RentalPricePerHour = 1200,
                ModelId = 3,
                Model = CarModels[2]
            },
            new()
            {
                Id = 4,
                Year = 2023,
                EngineVolume = 3.6,
                Transmission = "AT",
                RentalPricePerHour = 2800,
                ModelId = 4,
                Model = CarModels[3]
            },
            new()
            {
                Id = 5,
                Year = 2024,
                EngineVolume = 3.0,
                Transmission = "AT",
                RentalPricePerHour = 8000,
                ModelId = 5,
                Model = CarModels[4]
            },
            new()
            {
                Id = 6,
                Year = 2022,
                EngineVolume = 5.3,
                Transmission = "AT",
                RentalPricePerHour = 3500,
                ModelId = 6,
                Model = CarModels[5]
            },
            new()
            {
                Id = 7,
                Year = 2023,
                EngineVolume = 1.6,
                Transmission = "MT",
                RentalPricePerHour = 700,
                ModelId = 7,
                Model = CarModels[6]
            },
            new()
            {
                Id = 8,
                Year = 2024,
                EngineVolume = 2.5,
                Transmission = "AT",
                RentalPricePerHour = 1800,
                ModelId = 8,
                Model = CarModels[7]
            },
            new()
            {
                Id = 9,
                Year = 2022,
                EngineVolume = 2.7,
                Transmission = "MT",
                RentalPricePerHour = 1500,
                ModelId = 9,
                Model = CarModels[8]
            },
            new()
            {
                Id = 10,
                Year = 2023,
                EngineVolume = 1.8,
                Transmission = "CVT",
                RentalPricePerHour = 1600,
                ModelId = 10,
                Model = CarModels[9]
            },
            new()
            {
                Id = 11,
                Year = 2022,
                EngineVolume = 2.7,
                Transmission = "MT",
                RentalPricePerHour = 1400,
                ModelId = 11,
                Model = CarModels[10]
            },
            new()
            {
                Id = 12,
                Year = 2024,
                EngineVolume = 3.5,
                Transmission = "AT",
                RentalPricePerHour = 3200,
                ModelId = 12,
                Model = CarModels[11]
            },
            new()
            {
                Id = 13,
                Year = 2023,
                EngineVolume = 3.0,
                Transmission = "AT",
                RentalPricePerHour = 6000,
                ModelId = 13,
                Model = CarModels[12]
            },
            new()
            {
                Id = 14,
                Year = 2024,
                EngineVolume = 2.0,
                Transmission = "AT",
                RentalPricePerHour = 2800,
                ModelId = 14,
                Model = CarModels[13]
            },
            new()
            {
                Id = 15,
                Year = 2023,
                EngineVolume = 1.7,
                Transmission = "MT",
                RentalPricePerHour = 900,
                ModelId = 15,
                Model = CarModels[14]
            }
        };

        Cars = new()
        {
            new()
            {
                Id = 1,
                LicensePlate = "A001AA163",
                Color = "Black",
                ModelGenerationId = 1,
                ModelGeneration = ModelGenerations[0]
            },
            new()
            {
                Id = 2,
                LicensePlate = "B777BC163",
                Color = "Red",
                ModelGenerationId = 2,
                ModelGeneration = ModelGenerations[1]
            },
            new()
            {
                Id = 3,
                LicensePlate = "C123ET163",
                Color = "White",
                ModelGenerationId = 3,
                ModelGeneration = ModelGenerations[2]
            },
            new()
            {
                Id = 4,
                LicensePlate = "E555KH163",
                Color = "Green",
                ModelGenerationId = 4,
                ModelGeneration = ModelGenerations[3]
            },
            new()
            {
                Id = 5,
                LicensePlate = "K234MR163",
                Color = "Silver",
                ModelGenerationId = 5,
                ModelGeneration = ModelGenerations[4]
            },
            new()
            {
                Id = 6,
                LicensePlate = "M888OA163",
                Color = "Gray",
                ModelGenerationId = 6,
                ModelGeneration = ModelGenerations[5]
            },
            new()
            {
                Id = 7,
                LicensePlate = "N456RS163",
                Color = "Blue",
                ModelGenerationId = 7,
                ModelGeneration = ModelGenerations[6]
            },
            new()
            {
                Id = 8,
                LicensePlate = "O789TU163",
                Color = "Brown",
                ModelGenerationId = 8,
                ModelGeneration = ModelGenerations[7]
            },
            new()
            {
                Id = 9,
                LicensePlate = "P321XO163",
                Color = "White",
                ModelGenerationId = 9,
                ModelGeneration = ModelGenerations[8]
            },
            new()
            {
                Id = 10,
                LicensePlate = "S654AM163",
                Color = "Black",
                ModelGenerationId = 10,
                ModelGeneration = ModelGenerations[9]
            },
            new()
            {
                Id = 11,
                LicensePlate = "T987RE163",
                Color = "Orange",
                ModelGenerationId = 11,
                ModelGeneration = ModelGenerations[10]
            },
            new()
            {
                Id = 12,
                LicensePlate = "U246KN163",
                Color = "White",
                ModelGenerationId = 12,
                ModelGeneration = ModelGenerations[11]
            },
            new()
            {
                Id = 13,
                LicensePlate = "H135VT163",
                Color = "Black",
                ModelGenerationId = 13,
                ModelGeneration = ModelGenerations[12]
            },
            new()
            {
                Id = 14,
                LicensePlate = "SH579SA163",
                Color = "Gray",
                ModelGenerationId = 14,
                ModelGeneration = ModelGenerations[13]
            },
            new()
            {
                Id = 15,
                LicensePlate = "SCH864RO163",
                Color = "Blue",
                ModelGenerationId = 15,
                ModelGeneration = ModelGenerations[14]
            }
        };

        Rentals = new()
        {
            new()
            {
                Id = 1,
                CarId = 7,
                ClientId = 1,
                RentalDate = new DateTime(2024, 3, 1, 10, 0, 0),
                RentalHours = 48,
                Car = Cars[6],
                Client = Clients[0]
            },
            new()
            {
                Id = 2,
                CarId = 7,
                ClientId = 3,
                RentalDate = new DateTime(2024, 2, 25, 14, 30, 0),
                RentalHours = 72,
                Car = Cars[6],
                Client = Clients[2]
            },
            new()
            {
                Id = 3,
                CarId = 7,
                ClientId = 5,
                RentalDate = new DateTime(2024, 2, 20, 9, 15, 0),
                RentalHours = 24,
                Car = Cars[6],
                Client = Clients[4]
            },
            new()
            {
                Id = 4,
                CarId = 1,
                ClientId = 2,
                RentalDate = new DateTime(2024, 2, 27, 11, 45, 0),
                RentalHours = 96,
                Car = Cars[0],
                Client = Clients[1]
            },
            new()
            {
                Id = 5,
                CarId = 1,
                ClientId = 4,
                RentalDate = new DateTime(2024, 2, 25, 16, 0, 0),
                RentalHours = 120,
                Car = Cars[0],
                Client = Clients[3]
            },
            new()
            {
                Id = 6,
                CarId = 2,
                ClientId = 6,
                RentalDate = new DateTime(2024, 2, 23, 13, 20, 0),
                RentalHours = 72,
                Car = Cars[1],
                Client = Clients[5]
            },
            new()
            {
                Id = 7,
                CarId = 2,
                ClientId = 8,
                RentalDate = new DateTime(2024, 2, 18, 10, 10, 0),
                RentalHours = 48,
                Car = Cars[1],
                Client = Clients[7]
            },
            new()
            {
                Id = 8,
                CarId = 3,
                ClientId = 7,
                RentalDate = new DateTime(2024, 2, 28, 8, 30, 0),
                RentalHours = 36,
                Car = Cars[2],
                Client = Clients[6]
            },
            new()
            {
                Id = 9,
                CarId = 4,
                ClientId = 9,
                RentalDate = new DateTime(2024, 2, 15, 12, 0, 0),
                RentalHours = 96,
                Car = Cars[3],
                Client = Clients[8]
            },
            new()
            {
                Id = 10,
                CarId = 5,
                ClientId = 10,
                RentalDate = new DateTime(2024, 2, 28, 7, 0, 0),
                RentalHours = 168,
                Car = Cars[4],
                Client = Clients[9]
            },
            new()
            {
                Id = 11,
                CarId = 6,
                ClientId = 11,
                RentalDate = new DateTime(2024, 2, 22, 15, 45, 0),
                RentalHours = 72,
                Car = Cars[5],
                Client = Clients[10]
            },
            new()
            {
                Id = 12,
                CarId = 8,
                ClientId = 12,
                RentalDate = new DateTime(2024, 2, 26, 9, 20, 0),
                RentalHours = 48,
                Car = Cars[7],
                Client = Clients[11]
            },
            new()
            {
                Id = 13,
                CarId = 9,
                ClientId = 13,
                RentalDate = new DateTime(2024, 2, 29, 22, 0, 0),
                RentalHours = 60,
                Car = Cars[8],
                Client = Clients[12]
            },
            new()
            {
                Id = 14,
                CarId = 10,
                ClientId = 14,
                RentalDate = new DateTime(2024, 2, 24, 11, 30, 0),
                RentalHours = 96,
                Car = Cars[9],
                Client = Clients[13]
            },
            new()
            {
                Id = 15,
                CarId = 11,
                ClientId = 15,
                RentalDate = new DateTime(2024, 2, 10, 14, 15, 0),
                RentalHours = 120,
                Car = Cars[10],
                Client = Clients[14]
            },
            new()
            {
                Id = 16,
                CarId = 12,
                ClientId = 1,
                RentalDate = new DateTime(2024, 2, 29, 14, 0, 0),
                RentalHours = 48,
                Car = Cars[11],
                Client = Clients[0]
            },
            new()
            {
                Id = 17,
                CarId = 13,
                ClientId = 2,
                RentalDate = new DateTime(2024, 2, 5, 16, 45, 0),
                RentalHours = 72,
                Car = Cars[12],
                Client = Clients[1]
            },
            new()
            {
                Id = 18,
                CarId = 14,
                ClientId = 3,
                RentalDate = new DateTime(2024, 2, 12, 10, 10, 0),
                RentalHours = 36,
                Car = Cars[13],
                Client = Clients[2]
            },
            new()
            {
                Id = 19,
                CarId = 15,
                ClientId = 4,
                RentalDate = new DateTime(2024, 2, 16, 13, 30, 0),
                RentalHours = 84,
                Car = Cars[14],
                Client = Clients[3]
            }
        };
    }
}