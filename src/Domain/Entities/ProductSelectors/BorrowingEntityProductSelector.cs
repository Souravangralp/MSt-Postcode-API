namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class BorrowingEntityProductSelector : BaseAuditableEntity
{
    public int? BorrowingEntityProductSelector_ProductID { get; set; }

    public int? BorrowingEntityProductSelector_BorrowingEntityTypeID { get; set; }

    public int? BorrowingEntityProductSelector_CouncilZoningTypeID { get; set; }

    public int? HeedfulPoints { get; set; }

    public Product? BorrowingEntityProductSelector_Product { get; set; }

    public BorrowingEntityType? BorrowingEntityProductSelector_BorrowingEntityType { get; set; }

    public CouncilZoningCategory? BorrowingEntityProductSelector_CouncilZoningType { get; set; }
}
