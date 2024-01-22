using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductRepository : EfAsyncRepository<Product, ProductContext>, IProductRepository
{
    public ProductRepository(ProductContext context) : base(context)
    {
    }
}