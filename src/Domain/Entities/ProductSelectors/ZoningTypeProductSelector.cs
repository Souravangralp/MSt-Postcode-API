namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class ZoningTypeProductSelector : BaseAuditableEntity
{
    public int? ZoningTypeProductSelector_StateID { get; set; }

    public int? ZoningTypeProductSelector_ProductID { get; set; }

    public int? ZoningTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? ZoningTypeProductSelector_CouncilZoningCategoryID { get; set; }

    public required string Zone { get; set; }

    public State? ZoningTypeProductSelector_State { get; set; }

    public Product? ZoningTypeProductSelector_Product { get; set; }

    public CouncilZoningCategory? ZoningTypeProductSelector_CouncilZoningCategory { get; set; }

    public CouncilZoningCategory? ZoningTypeProductSelector_CouncilZoningType { get; set; }
}
