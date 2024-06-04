namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class SelfEmployedClassificationProductSelector : BaseAuditableEntity
{
    public int? SelfEmployedClassificationProductSelector_SelfEmployedClassificationID { get; set; }

    public int? SelfEmployedClassificationProductSelector_ProductID { get; set; }

    public SelfEmployedClassification? SelfEmployedClassificationProductSelector_SelfEmployedClassification { get; set; }

    public Product? SelfEmployedClassificationProductSelector_Product { get; set; }
}
