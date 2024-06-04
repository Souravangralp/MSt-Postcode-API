namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class AgeOfCreditReportDto
{
    public int FromDays { get; set; }
    
    public int ToDays { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
