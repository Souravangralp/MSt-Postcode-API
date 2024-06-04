namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IHeedFullPointsProductSelectorsService
{
    Task<List<int?>> GetProducts(string heedfullPointType);
}
