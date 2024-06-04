namespace ProductMatrix.Domain.Entities.Products;

public class NumeralClassification : BaseAuditableEntity
{
    public required double LoanAmountFrom { get; set; }

    public required double LoanAmountTo { get; set; }

    public required string NumeralType { get; set; }
}
