namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class GuidedByTypeProductSelector : BaseAuditableEntity
{
    public int? GuidedByTypeProductSelector_ProductID { get; set; }

    public int? GuidedByTypeProductSelector_GeneralLookUpID { get; set; }

    public int? GuidedByTypeProductSelector_CouncilZoningTypeID { get; set; }

    public Product? GuidedByTypeProductSelector_Product { get; set; }

    public GeneralLookUp? GuidedByTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? GuidedByTypeProductSelector_CouncilZoningType { get; set; }
}
