namespace ProductMatrix.Domain.Entities;

public class ApplicationObjectiveClassification : BaseAuditableEntity
{
    public int? ApplicationObjectiveClassification_CouncilZoningTypeID { get; set; }

    public int? EquityType_GeneralLookUpID { get; set; }

    public int? UsageType_GeneralLookUpID { get; set; }

    public int? AwayBankType_GeneralLookUpID { get; set; }

    [Comment("How many loans have for consolidation.")]
    public int? ConsolidateForm {  get; set; }

    public int? ConsolidateTo {  get; set; }

    public int? HeedFulPoints { get; set; }

    public GeneralLookUp? UsageType_GeneralLookUp { get; set; }

    public GeneralLookUp? EquityType_GeneralLookUp { get; set; }

    public GeneralLookUp? AwayBankType_GeneralLookUp { get; set; }

    public CouncilZoningCategory? ApplicationObjectiveClassification_CouncilZoningType { get; set; }
}
