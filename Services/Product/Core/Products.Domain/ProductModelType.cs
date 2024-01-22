using BusinessApp.Shared.Domain.Models.Commons;

namespace Products.Domain;

public class ProductModelType : BaseEntity
{
    public string ProductModelCode { get; set; }
    public string ProductModelName { get; set; }
    public string? ProductModelDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; }


}