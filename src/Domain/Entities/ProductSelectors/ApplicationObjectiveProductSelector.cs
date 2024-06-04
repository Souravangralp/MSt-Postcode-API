namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class ApplicationObjectiveProductSelector : BaseAuditableEntity
{
    public int? ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID { get; set; }

    public int? ApplicationObjectiveProductSelector_ProductID { get; set; }

    public ApplicationObjectiveClassification? ApplicationObjectiveProductSelector_ApplicationObjectiveClassification { get; set; }

    public Product? ApplicationObjectiveProductSelector_Product { get; set; }
}
