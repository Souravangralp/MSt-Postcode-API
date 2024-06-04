namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface ILoanAmountProductSelectorService
{
    Task<List<int?>> GetProducts(string loanType, string doctype, double loanAmount, int councilZoningID);
}
