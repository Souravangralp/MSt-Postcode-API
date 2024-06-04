namespace ProductMatrix.Application.Common.Interfaces.ProductCalculators;

public interface IOtherIncomeProductSelectorService
{
    Task<List<int?>> GetProducts(string incomeType);
}
