namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IApplicationFeeService
{
    Task<double> CalculateApplicationFee(string formulaType, ProductFeeDto productFeeDto);
}
