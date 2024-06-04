namespace ProductMatrix.Domain.Entities.Products;

public class LoanToValueRatio : BaseAuditableEntity
{
    public double From { get; set; }

    public double To { get; set; }
}
