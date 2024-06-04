namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class ButtonTypeProductSelector : BaseAuditableEntity
{
    public int? ButtonTypeProductSelector_ProductID { get; set; }

    public int? ButtonTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? ButtonTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? ButtonTypeProductSelector_Product { get; set; }

    public GeneralLookUp? ButtonTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? ButtonTypeProductSelector_CouncilZoningType { get; set; }
}
