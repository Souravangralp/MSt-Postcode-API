namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class FacilityTypeProductSelector : BaseAuditableEntity
{
    public int? FacilityTypeProductSelector_ProductID { get; set; }

    public int? FacilityTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? FacilityTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? FacilityTypeProductSelector_Product { get; set; }

    public GeneralLookUp? FacilityTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? FacilityTypeProductSelector_CouncilZoningType { get; set; }
}
