using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductRepository : EfAsyncRepository<Product, Guid, ProductContext>, IProductRepository
{
    public ProductRepository(ProductContext context) : base(context)
    {
    }
}