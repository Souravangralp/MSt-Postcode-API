namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IDwellingProductSelectorService
{
    Task<List<int?>> GetProducts(string postcode, int dwellings);
}
