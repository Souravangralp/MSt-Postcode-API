namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IApplicationObjectiveProductSelectorService
{
    Task<List<int?>> GetProducts(string equityType, string usageType, string? awayBankType, int consolidateLoan, int councilZoningId);
}
