namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class RepaymentTypeProductSelector : BaseAuditableEntity
{
    public int? RepaymentTypeProductSelector_ProductID { get; set; }

    public int? RepaymentTypeProductSelector_CouncilZoningTypeID { get; set; }

    public required string RepaymentType { get; set; }

    public required string RateType { get; set; }

    public required int TimeInYears { get; set; }

    public int? HeedfulPoints { get; set; }

    public Product? RepaymentTypeProductSelector_Product { get; set; }

    public CouncilZoningCategory? RepaymentTypeProductSelector_CouncilZoningType { get; set; }
}
