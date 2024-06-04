namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class MaritalStatusProductSelector : BaseAuditableEntity
{
    public int? MaritalStatusProductSelector_ProductID { get; set; }

    public int? MaritalStatusProductSelector_CouncilZoningCategoryTypeID { get; set; }

    public required string Status { get; set; }

    public Product? MaritalStatusProductSelector_Product { get; set; }

    public CouncilZoningCategory? MaritalStatusProductSelector_CouncilZoningCategoryType { get; set; }
}
