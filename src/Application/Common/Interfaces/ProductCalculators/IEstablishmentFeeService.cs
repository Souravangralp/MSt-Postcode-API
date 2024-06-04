namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IEstablishmentFeeService
{
    Task<double> CalculateEstablishmentPercent(string formulaType, ProductFeeDto productFeeDto);

    Task<double> CalculateEstablishmentFee(double loanAmount, double establishmentPercent);
}
