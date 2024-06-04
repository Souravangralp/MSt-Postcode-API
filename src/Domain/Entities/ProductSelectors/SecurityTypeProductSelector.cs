namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class SecurityTypeProductSelector : BaseAuditableEntity
{
    public int? SecurityTypeProductSelector_ProductID { get; set; }

    public int? SecurityTypeProductSelector_GeneralLookUpID { get; set; }

    public int? SecurityTypeProductSelector_CouncilZoningTypeID { get; set; }

    public Product? SecurityTypeProductSelector_Product { get; set; }

    public GeneralLookUp? SecurityTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? SecurityTypeProductSelector_CouncilZoningType { get; set; }
}
