namespace ProductMatrix.Domain.Entities.Calculator;

public class ProductFeeLVRRate : BaseAuditableEntity
{
    public int? ProductFeeLVRRate_ProductID { get; set; }

    public int? ProductFeeLVRRate_DocTypeID { get; set; }

    public required string FeeType { get; set; }

    [Comment("LVR means loan value ratio")]
    public required double LVRFrom { get; set; }

    public required double LVRTo { get; set; }

    public required double RatePercentIncrementDecrement { get; set; }

    public Product? ProductFeeLVRRate_Product { get; set; }

    public DocType? ProductFeeLVRRate_DocType { get; set; }
}
