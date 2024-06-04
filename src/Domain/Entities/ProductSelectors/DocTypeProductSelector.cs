namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class DocTypeProductSelector : BaseAuditableEntity
{
    public int? DocTypeProductSelector_DocTypeID { get; set; }

    public int? DocTypeProductSelector_CouncilZoningTypeID { get; set; }

    public int? DocTypeProductSelector_ProductID { get; set; }

    public required int MinimumLoanTermInYears { get; set; }

    public required int MaximumLoanTermInYears { get; set; }

    public int? HeedfulPoints { get; set; }

    public DocType? DocTypeProductSelector_DocType { get; set; }

    public CouncilZoningCategory? DocTypeProductSelector_CouncilZoningType { get; set; }

    public Product? DocTypeProductSelector_Product { get; set; }
}
