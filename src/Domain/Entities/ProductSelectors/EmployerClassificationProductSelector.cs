namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class EmployerClassificationProductSelector : BaseAuditableEntity
{
    public int? EmployerClassificationProductSelector_ProductID { get; set; }

    public required string EmployerClassificationType { get; set; }

    public Product? EmployerClassificationProductSelector_Product { get; set; }
}
