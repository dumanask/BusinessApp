using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductCatalogRepository : EfAsyncRepository<ProductCatalog, Guid, ProductContext>, IProductCatalogRepository
{
    public ProductCatalogRepository(ProductContext context) : base(context)
    {
    }
}