namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ISecurityTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string securityType, int councilZoningId);
}
