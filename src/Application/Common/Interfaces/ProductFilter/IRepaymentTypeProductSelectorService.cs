namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IRepaymentTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string repaymentType, string? rateType, int? timeInYears, int councilZoningID);
}
