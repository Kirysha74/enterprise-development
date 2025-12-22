using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarGetDto>();
        CreateMap<CarEditDto, Car>();

        CreateMap<Client, ClientGetDto>();
        CreateMap<ClientEditDto, Client>();

        CreateMap<CarModel, CarModelGetDto>();
        CreateMap<CarModelEditDto, CarModel>();

        CreateMap<ModelGeneration, ModelGenerationGetDto>();
        CreateMap<ModelGenerationEditDto, ModelGeneration>();

        CreateMap<Rental, RentalGetDto>();
        CreateMap<RentalEditDto, Rental>();
    }
}