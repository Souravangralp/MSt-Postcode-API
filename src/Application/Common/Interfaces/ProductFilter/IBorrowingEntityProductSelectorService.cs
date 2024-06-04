namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IBorrowingEntityProductSelectorService
{
    Task<List<int?>> GetProducts(string borrowingEntityType, int councilZoningID);
}
