namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class OtherIncomeTypeProductSelector : BaseAuditableEntity
{
    public int? OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID { get; set; }

    public int? OtherIncomeTypeProductSelector_OtherIncomeTypeID { get; set; }

    public int? OtherIncomeTypeProductSelector_ProductID { get; set; }

    public OtherIncomeType? OtherIncomeTypeProductSelector_OtherIncomeType { get; set; }

    public Product? OtherIncomeTypeProductSelector_Product { get; set; }

    public CouncilZoningCategory? OtherIncomeTypeProductSelector_CouncilZoningCategoryType { get; set; }
}
