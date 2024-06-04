namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IEmploymentClassificationProductSelectorService
{
    Task<List<int?>> GetProducts(string employmentStatusType, int experienceOfWorkInMonths, bool isSameLineOfWork, int councilZoningID);
}
