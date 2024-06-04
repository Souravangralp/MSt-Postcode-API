namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IAgeCreditReportProductSelectorService
{
    Task<List<int?>> GetProducts(int ageCreditReport);
}
