namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class EmploymentClassificationDto
{
    public int? ID { get; set; }

    public required string EmploymentStatusType { get; set; }

    public required int MinimumExperienceOfWorkInMonths { get; set; }

    public required int MaximumExperienceOfWorkInMonths { get; set; }

    public bool ISSameLineOfWork { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
