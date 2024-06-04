namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ILvrProductSelectorService
{
    Task<List<int?>> GetProducts(string residencyType, double lvr);
}
