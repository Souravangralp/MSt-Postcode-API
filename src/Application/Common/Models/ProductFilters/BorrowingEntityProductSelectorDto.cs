namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class BorrowingEntityProductSelectorDto
{
    public int ID { get; set; }

    public required string BorrowingEntity { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
