namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class ServiceTypeProductSelector : BaseAuditableEntity
{
    public int? ServiceTypeProductSelector_ProductID { get; set; }

    public int? ServiceTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? ServiceTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? ServiceTypeProductSelector_Product { get; set; }

    public GeneralLookUp? ServiceTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? ServiceTypeProductSelector_CouncilZoningType { get; set; }
}
