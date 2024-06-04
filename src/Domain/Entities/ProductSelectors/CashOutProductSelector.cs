namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class CashOutProductSelector : BaseAuditableEntity
{
    public int? CashOutProductSelector_BusinessFinanceTypeID { get; set; }

    public int? CashOutProductSelector_CashOutTypeID { get; set; }

    public int? CashOutProductSelector_ProductID { get; set; }

    public BusinessFinanceType? CashOutProductSelector_BusinessFinanceType { get; set; }

    public CashOutType? CashOutProductSelector_CashOutType { get; set; }

    public Product? CashOutProductSelector_Product {  get; set; }
}
