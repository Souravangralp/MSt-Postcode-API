namespace ProductMatrix.Domain.Entities.Products;

public class ProductCategory : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public IList<Product> Products { get; set; } = [];
}
