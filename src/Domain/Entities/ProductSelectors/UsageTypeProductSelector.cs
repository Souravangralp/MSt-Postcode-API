namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class UsageTypeProductSelector : BaseAuditableEntity
{
    public int? UsageTypeProductSelector_ProductID { get; set; }

    public int? UsageTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? UsageTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? UsageTypeProductSelector_Product { get; set; }

    public GeneralLookUp? UsageTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? UsageTypeProductSelector_CouncilZoningType { get; set; }
}
