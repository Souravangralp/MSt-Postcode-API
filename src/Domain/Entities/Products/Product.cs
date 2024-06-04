namespace ProductMatrix.Domain.Entities.Products;

public class Product : BaseAuditableEntity
{
    public int? Product_ProductCategoryID { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required double RangeFrom { get; set; }

    public required double RangeTo { get; set; }

    public ProductCategory? Product_ProductCategory { get; set; }
}
