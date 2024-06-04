using ProductMatrix.Domain.Entities.ProductSelectors;

namespace ProductMatrix.Domain.Entities;

public class EmploymentClassification : BaseAuditableEntity
{
    public int? EmploymentClassification_CouncilZoningCategoryID { get; set; }

    public required string EmploymentStatusType { get; set; }

    public required int MinimumExperienceOfWorkInMonths { get; set; }

    public required int MaximumExperienceOfWorkInMonths { get; set; }

    public bool ISSameLineOfWork { get; set; }

    public CouncilZoningCategory? EmploymentClassification_CouncilZoningCategory { get; set; }

    public List<EmploymentClassificationProductSelector> EmploymentClassificationProductSelectors { get; set; } = [];
}
