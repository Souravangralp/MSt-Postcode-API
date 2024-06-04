namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ILandSizeProductSelectorService
{
    Task<List<int?>> GetProducts(int landSize, int councilZoningId);
}
