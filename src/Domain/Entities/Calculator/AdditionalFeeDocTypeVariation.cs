namespace ProductMatrix.Domain.Entities.Calculator;

public class AdditionalFeeDocTypeVariation : BaseAuditableEntity
{
    public required int? AdditionalFeeDocTypeVariation_DocTypeID { get; set; }

    public required string FormulaType { get; set; }

    public required string FeeType { get; set; }

    public required double Value { get; set; }
    
    public DocType? AdditionalFeeDocTypeVariation_DocType { get; set; }
}
