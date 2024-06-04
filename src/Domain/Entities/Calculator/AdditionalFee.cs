namespace ProductMatrix.Domain.Entities.Calculator;

public class AdditionalFee : BaseAuditableEntity
{
    public int? AdditionalFee_LoanToValueRatioID { get; set; }

    public int? AdditionalFee_DocTypeID { get; set; }

    public int? AdditionalFee_VacantLandCategoryID { get; set; }

    public int? AdditionalFee_LandSizeID { get; set; }

    public required double IncrementFee { get; set; }

    public required string FeeType { get; set; }

    public LoanToValueRatio? AdditionalFee_LoanToValueRatio { get; set; }

    public DocType? AdditionalFee_DocType { get; set; }

    public VacantLandCategory? AdditionalFee_VacantLandCategory { get; set; }

    public LandSize? AdditionalFee_LandSize { get; set; }
}
