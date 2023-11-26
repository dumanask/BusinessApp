using AutoMapper;
using Products.Application.Features.ProductCardTypes.Commands.Create;
using Products.Domain;

namespace Products.Application.Features.ProductCardTypes.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductCardType, CreateProductCardTypeCommand>().ReverseMap();
        CreateMap<ProductCardType, CreateProductCardTypeResponse>().ReverseMap();
    }
    
}