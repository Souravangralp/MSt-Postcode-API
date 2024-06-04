namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class NaturalPersonAgeProductSelector : BaseAuditableEntity
{
    public int? NaturalPersonAgeProductSelector_ProductID { get; set; }

    public int? NaturalPersonAgeProductSelector_CouncilZoningTypeID { get; set; }

    public required int MinimumAge { get; set; }

    public required int MaximumAge { get; set; }

    public int? HeedfulPoints { get; set; }

    public Product? NaturalPersonAgeProductSelector_Product { get; set; }

    public CouncilZoningCategory? NaturalPersonAgeProductSelector_CouncilZoningType { get; set; }
}
