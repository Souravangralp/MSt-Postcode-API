namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class LoanAmountProductSelector : BaseAuditableEntity
{
    public int? LoanAmountProductSelector_DocTypeID { get; set; }

    public int? LoanAmountProductSelector_CouncilZoningTypeID { get; set; }    

    public int? LoanAmountProductSelector_ProductID { get; set; }

    public string? LoanType { get; set; }

    public DocType? LoanAmountProductSelector_DocType { get; set; }

    public CouncilZoningCategory? LoanAmountProductSelector_CouncilZoningType { get; set; }

    public Product? LoanAmountProductSelector_Product { get; set; }
}
