namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IUsageTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string secondaryUsageType, int councilZoningId);
}
