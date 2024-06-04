namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IEmployerClassificationProductSelectorService
{
    Task<List<int?>> GetProducts(string employerType);
}
