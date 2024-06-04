namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IRateLoadingService
{
    Task<double> CalculateRateLoading(string formulaType, ProductFeeDto productFeeDto);
}
