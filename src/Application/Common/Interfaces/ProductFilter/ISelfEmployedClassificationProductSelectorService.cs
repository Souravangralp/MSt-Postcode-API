namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ISelfEmployedClassificationProductSelectorService
{
    Task<List<int?>> GetProducts(string docType, int selfEmployedTimeInMonths);
}
