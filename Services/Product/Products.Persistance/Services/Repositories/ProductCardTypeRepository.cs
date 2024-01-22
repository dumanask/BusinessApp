using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductCardTypeRepository :EfAsyncRepository<ProductCardType, ProductContext>, IProductCardTypeRepository
{
    public ProductCardTypeRepository(ProductContext context) : base(context)
    {
    }
}