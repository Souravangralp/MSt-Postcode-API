namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class RulesFilterDto
{
    public int ID { get; set; }

    public string FilterName { get; set; } = string.Empty;

    public int? CouncilZoningID { get; set; }

    public List<RulesFilterDto> SubFilters { get; set; } = [];
}
