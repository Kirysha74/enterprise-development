using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarGetDto>()
            .ForMember(dest => dest.ModelGeneration,
                       opt => opt.MapFrom(src => src.ModelGeneration));

        CreateMap<CarEditDto, Car>();

        CreateMap<Client, ClientGetDto>();
        CreateMap<ClientEditDto, Client>();

        CreateMap<CarModel, CarModelGetDto>();
        CreateMap<CarModelEditDto, CarModel>();

        CreateMap<ModelGeneration, ModelGenerationGetDto>()
            .ForMember(dest => dest.Model,
                       opt => opt.MapFrom(src => src.Model));
        CreateMap<ModelGenerationEditDto, ModelGeneration>();

        CreateMap<Rental, RentalGetDto>()
            .ForMember(dest => dest.Car,
                       opt => opt.MapFrom(src => src.Car))
            .ForMember(dest => dest.Client,
                       opt => opt.MapFrom(src => src.Client));
        CreateMap<RentalEditDto, Rental>();
    }
}