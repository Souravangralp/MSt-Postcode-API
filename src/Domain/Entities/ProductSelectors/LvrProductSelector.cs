namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class LvrProductSelector : BaseAuditableEntity
{
    public int? LvrProductSelector_ProductID { get; set; }

    public double MaximumLVR { get; set; }

    public required string ResidencyType { get; set; }

    public Product? LvrProductSelector_Product { get; set; }
}
