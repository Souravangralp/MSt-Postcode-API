namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class LandSizeProductSelector : BaseAuditableEntity
{
    public int? LandSizeProductSelector_ProductID { get; set; }

    public int? LandSizeProductSelector_LandSizeClassificationID { get; set; }

    public Product? LandSizeProductSelector_Product { get; set; }

    public LandSizeClassification? LandSizeProductSelector_LandSizeClassification { get; set; }
}
