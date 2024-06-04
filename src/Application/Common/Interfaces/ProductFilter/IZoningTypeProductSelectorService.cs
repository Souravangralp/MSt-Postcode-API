namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IZoningTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string councilZoningCategory, string zone, string state, int councilZoningTypeId);
}
