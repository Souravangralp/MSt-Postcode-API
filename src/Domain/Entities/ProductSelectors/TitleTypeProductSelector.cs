namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class TitleTypeProductSelector : BaseAuditableEntity
{
    public int? TitleTypeProductSelector_ProductID { get; set; }

    public int? TitleTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? TitleTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? TitleTypeProductSelector_Product { get; set; }

    public GeneralLookUp? TitleTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? TitleTypeProductSelector_CouncilZoningType { get; set; }
}
