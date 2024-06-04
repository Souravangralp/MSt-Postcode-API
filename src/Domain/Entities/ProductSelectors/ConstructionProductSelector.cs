namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class ConstructionProductSelector : BaseAuditableEntity
{
    public int? ConstructionProductSelector_CouncilZoningTypeID { get; set; }

    public int? ConstructionProductSelector_ConstructionTypeID { get; set; }

    public int? ConstructionProductSelector_BuilderTypeID { get; set; }

    public int? ConstructionProductSelector_ProductID { get; set; }

    public int? ConstructionProductSelector_RenovationTypeID { get; set; }

    public bool ISGreenRated { get; set; }

    public CouncilZoningCategory? ConstructionProductSelector_CouncilZoningType { get; set; }

    public ConstructionType? ConstructionProductSelector_ConstructionType { get; set; }

    public BuilderType? ConstructionProductSelector_BuilderType { get; set; }

    public Product? ConstructionProductSelector_Product { get; set; }

    public RenovationType? ConstructionProductSelector_RenovationType { get; set; }
}
