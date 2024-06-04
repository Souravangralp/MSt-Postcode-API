namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IDocTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string docType, int loanTermInYears, int councilZoningID);
}
