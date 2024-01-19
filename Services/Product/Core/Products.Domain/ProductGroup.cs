using BusinessApp.Shared.Domain.Models.Commons;

namespace Products.Domain;

public class ProductGroup : BaseEntity<Guid>
{
    public string ProductGroupCode { get; set; }
    public string ProductGroupName { get; set; }
    public string? ProductGroupDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; }

}