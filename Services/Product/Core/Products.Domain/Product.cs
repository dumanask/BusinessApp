using Shared;
using Shared.Enums;

namespace Products.Domain;

public class Product : BaseEntity<Guid>
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string? Description { get; set; }
    public UnitType UnitType { get; set; }
    public float? Stock { get; set; }
    public float? Price { get; set; }
}