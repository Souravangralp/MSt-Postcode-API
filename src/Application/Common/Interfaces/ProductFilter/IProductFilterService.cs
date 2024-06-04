namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IProductFilterService
{
    Task<List<int>> RemoveDuplicates(List<int?> productIds);

    Task<TextValuePair[]> GetEligibleProducts(List<int> productIds);
}
