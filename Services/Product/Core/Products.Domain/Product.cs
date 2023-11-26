using Shared;
using Shared.Enums;

namespace Products.Domain;

public class Product : BaseEntity<Guid>
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string? Description { get; set; }
    public UnitType UnitType { get; set; }
    public Guid ProductCardTypeId { get; set; }
    public Guid ProductModelTypeId { get; set; }
    public Guid ProductGroupId { get; set; }
    public Guid ProductStatusId { get; set; }
    public Guid ProductCatalogId { get; set; }
    
}