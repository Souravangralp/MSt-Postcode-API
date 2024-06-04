namespace ProductMatrix.Domain.Entities.Calculator;

public class DefaultFee : BaseAuditableEntity
{
    public string? FormulaType { get; set; }

    public int? DefaultFee_DocTypeID { get; set; }

    public int? DefaultFee_LoanToValueRatioID { get; set; }

    public int? DefaultFee_ProductID { get; set; }

    public double? ApplicationFee { get; set; }

    public double? AnnualFee { get; set; }

    public double? RiskFee { get; set; }

    public double? EstablishmentFee { get; set; }

    public double? SettlementFee { get; set; }

    public double? DischargeFee { get; set; }

    public double? RateLoadingFee { get; set; }

    public double? DeedOfPriorityFee { get; set; }

    public double? ExpressFee { get; set; }

    public DocType? DefaultFee_DocType { get; set; }

    public LoanToValueRatio? DefaultFee_LoanToValueRatio { get; set; }

    public Product? DefaultFee_Product { get; set; }
}
