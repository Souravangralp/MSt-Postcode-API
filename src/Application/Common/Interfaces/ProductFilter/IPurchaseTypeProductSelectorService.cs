namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IPurchaseTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string docType, string OccupancyType, double lvr, int councilZoningID);
}
