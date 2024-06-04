namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IAnnualFacilityFeeService
{
    Task<double> CalculateAnnualFacilityFee(string formulaType, ProductFeeDto productFeeDto);
}
