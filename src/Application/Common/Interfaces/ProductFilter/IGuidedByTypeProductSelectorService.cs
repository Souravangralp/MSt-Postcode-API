namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IGuidedByTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string guidedByType);
}
