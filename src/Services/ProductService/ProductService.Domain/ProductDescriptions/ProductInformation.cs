using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;

namespace ProductService.Domain.ProductDescriptions;

public class ProductInformation : ProductProperty
{
    public Guid StatusId { get; set; }
    public Guid MainUnitId { get; set; }
    public string Description { get; set; }
    public string? AlternativeCodeName { get; set; }
    public string? RevisionCodeName { get; set; }
}
