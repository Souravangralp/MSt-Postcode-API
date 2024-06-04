namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ICashOutProductSelectorService
{
    Task<List<int?>> GetProducts(string cashOutType, string businessFinanceType);
}
