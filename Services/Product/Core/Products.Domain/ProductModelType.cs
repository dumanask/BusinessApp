using Shared;

namespace Products.Domain;

public class ProductModelType : BaseEntity<Guid>
{
    public string ProductModelCode { get; set; }
    public string ProductModelName { get; set; }
    public string? ProductModelDescription { get; set; }
    
}