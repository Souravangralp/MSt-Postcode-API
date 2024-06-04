namespace ProductMatrix.Domain.Entities;

public class RulesFilter : BaseAuditableEntity
{
    public int? FilterType_GeneralLookUpID { get; set; }

    public int? RulesFilter_CouncilZoningTypeID { get; set; }

    public int? ParentRuleFilterID { get; set; }

    public GeneralLookUp? FilterType_GeneralLookUp { get; set; }

    public CouncilZoningCategory? RulesFilter_CouncilZoningType { get; set; }
}
