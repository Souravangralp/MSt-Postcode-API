namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IGetDefaultFeeService 
{
    Task<double> GetFee(string feeType, string formulaType, int docTypeId);
}
