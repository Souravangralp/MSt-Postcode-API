namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IDeedOfPriorityService
{
    Task<double> CalculateDeedOfPriority(string formulaType, ProductFeeDto productFeeDto);
}
