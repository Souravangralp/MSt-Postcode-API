namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class EmploymentClassificationProductSelector : BaseAuditableEntity
{
    public int? EmploymentClassificationProductSelector_EmploymentClassificationID { get; set; }

    public int? EmploymentClassificationProductSelector_ProductID { get; set; }

    public EmploymentClassification? EmploymentClassificationProductSelector_EmploymentClassification { get; set; }

    public Product? EmploymentClassificationProductSelector_Product { get; set; }
}
