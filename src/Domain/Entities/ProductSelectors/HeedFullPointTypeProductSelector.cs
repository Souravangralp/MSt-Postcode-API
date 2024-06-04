namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class HeedFullPointTypeProductSelector : BaseAuditableEntity
{
    public int? HeedFullPointTypeProductSelector_ProductID { get; set; }

    public int? HeedFullPointTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? HeedFullPointTypeProductSelector_GeneralLookUpID { get; set; }

    public Product? HeedFullPointTypeProductSelector_Product { get; set; }

    public GeneralLookUp? HeedFullPointTypeProductSelector_GeneralLookUp { get; set; }

    public CouncilZoningCategory? HeedFullPointTypeProductSelector_CouncilZoningType { get; set; }
}
