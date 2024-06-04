namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IPotentialImpactfulConsiderationProductSelectorService
{
    Task<List<int?>> GetProducts(string potentialImpactfulType);
}
