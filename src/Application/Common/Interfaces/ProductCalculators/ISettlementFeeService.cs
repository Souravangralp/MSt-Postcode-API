namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface ISettlementFeeService 
{
    Task<double> CalculateSettlementFee(string formulaType, ProductFeeDto productFeeDto);
}
