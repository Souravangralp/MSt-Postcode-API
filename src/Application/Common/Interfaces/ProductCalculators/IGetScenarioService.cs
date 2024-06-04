using ProductMatrix.Application.Products.Queries.CalculateProductFee;

namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IGetScenarioService
{
    public Task<string> GetFormula(CalculateProductFee calculateProductFee);

}
