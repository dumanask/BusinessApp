using AutoMapper;
using Products.Application.Features.Products.Commands.Create;
using Products.Application.Features.Products.Commands.CreateList;
using Products.Application.Features.Products.Commands.Delete;
using Products.Application.Features.Products.Commands.DeleteList;
using Products.Application.Features.Products.Commands.Update;
using Products.Application.Features.Products.Commands.UpdateList;
using Products.Application.Features.Products.Queries.GetAllProducts;
using Products.Application.Features.Products.Queries.GetProductById;
using Products.Domain;

namespace Products.Application.Features.Products.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreateProductResponse>().ReverseMap();
        CreateMap<Product, CreateProductsInListCommand>().ReverseMap();
        CreateMap<Product, CreateProductsInListResponse>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductResponse>().ReverseMap();
        CreateMap<Product, UpdateProductsInListCommand>().ReverseMap();
        CreateMap<Product, UpdateProductsInListResponse>().ReverseMap();
        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Product, DeleteProductResponse>().ReverseMap();
        CreateMap<Product, DeleteProductsInListCommand>().ReverseMap();
        CreateMap<Product, DeleteProductsInListResponse>().ReverseMap();
        CreateMap<Product, GetProductByProductIdResponse>()
            .ForMember(destinationMember: x => x.Id, memberOptions: opt => opt.MapFrom(x => x.Id)).ReverseMap();
        CreateMap<Product, GetAllProductsResponse>().ReverseMap();
    }

}