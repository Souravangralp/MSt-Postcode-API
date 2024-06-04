namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IDischargeFeeService
{
    Task<double> CalculateDischargeFee(string formulaType, ProductFeeDto productFeeDto);
}
