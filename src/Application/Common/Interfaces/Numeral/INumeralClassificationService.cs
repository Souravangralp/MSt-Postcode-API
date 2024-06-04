namespace ProductMatrix.Application.Common.Interfaces.Numeral;

public interface INumeralClassificationService
{
    Task<string?> GetNumeralType(double loanAmount);
}
