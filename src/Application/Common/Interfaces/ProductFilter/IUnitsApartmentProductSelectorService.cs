namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IUnitsApartmentProductSelectorService
{
    Task<List<int?>> GetProducts(double livingAreaSize);
}
