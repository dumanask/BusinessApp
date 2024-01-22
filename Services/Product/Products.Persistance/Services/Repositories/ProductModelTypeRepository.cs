using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductModelTypeRepository : EfAsyncRepository<ProductModelType, ProductContext>, IProductModelTypeRepository
{
    public ProductModelTypeRepository(ProductContext context) : base(context)
    {
    }
}