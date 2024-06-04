namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class DwellingsProductSelector : BaseAuditableEntity
{
    public int? DwellingsProductSelector_CouncilZoningCategoryTypeID { get; set; }

    public int? DwellingsProductSelector_ProductID { get; set; }

    public required string PCCategory { get; set; }

    public required int DwellingCount { get; set; }

    public Product? DwellingsProductSelector_Product { get; set; }

    public CouncilZoningCategory? DwellingsProductSelector_CouncilZoningCategoryType { get; set; }
}
