namespace Products.Application.Features.Products.Queries.GetProductById;

public class GetProductByProductIdResponse
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
}