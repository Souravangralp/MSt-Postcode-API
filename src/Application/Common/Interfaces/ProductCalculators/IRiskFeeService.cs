namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IRiskFeeService
{
    Task<double> CalculateRiskPercent(string formulaType, ProductFeeDto productFeeDto);

    Task<double> CalculateRiskFee(double loanAmount, double riskFee);
}
