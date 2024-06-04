namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IServiceTypeProductSelectorsService
{
    Task<List<int?>> GetProducts(string serviceType, int councilZoningId);
}
