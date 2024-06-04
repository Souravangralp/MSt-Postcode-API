namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ITitleTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string titleType, int councilZoningId);
}
