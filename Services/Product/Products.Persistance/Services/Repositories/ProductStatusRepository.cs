using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductStatusRepository : EfAsyncRepository<ProductStatus, ProductContext>, IProductStatusRepository
{
    public ProductStatusRepository(ProductContext context) : base(context)
    {
    }
}