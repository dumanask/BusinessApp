using Shared;

namespace Products.Domain;

public class ProductStatus: BaseEntity<Guid>
{
    public string ProductStatusCode { get; set; }
    public string ProductStatusName { get; set; }
    public string? ProductStatusDescription { get; set; }
}