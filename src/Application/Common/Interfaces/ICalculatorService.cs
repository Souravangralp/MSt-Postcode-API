using ProductMatrix.Application.Products.Queries.CalculateProductFee;

namespace ProductMatrix.Application.Common.Interfaces;

public interface ICalculatorService 
{
    Task<ProductFeeResult> CalculateProductFee(string formulaType, CalculateProductFee calculateProductFee);

    Task<List<ProductFeeResult>> GetSuggestedProductFees(string formulaType, ProductFeeDto productFeeDto);
}
