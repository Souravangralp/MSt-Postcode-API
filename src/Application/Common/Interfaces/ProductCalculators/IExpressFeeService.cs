namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IExpressFeeService
{
    Task<double> CalculateExpressFee(string formulaType, ProductFeeDto productFeeDto);
}
