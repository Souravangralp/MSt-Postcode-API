using ProductMatrix.Application.Common.Models.ProductSelectors;

namespace ProductMatrix.Application.Common.Interfaces;

public interface IProductSelectionService 
{
    Task<TextValuePair[]> GetEligibleProducts(ProductScenarioBuilder productScenarioBuilder);
}
