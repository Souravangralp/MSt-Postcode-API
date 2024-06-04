namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IButtonTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string buttonValue, int councilZoningId);
}
