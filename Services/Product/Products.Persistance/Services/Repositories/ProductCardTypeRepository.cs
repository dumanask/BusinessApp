using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductCardTypeRepository :EfAsyncRepository<ProductCardType, Guid, ProductContext>, IProductCardTypeRepository
{
    public ProductCardTypeRepository(ProductContext context) : base(context)
    {
    }
}