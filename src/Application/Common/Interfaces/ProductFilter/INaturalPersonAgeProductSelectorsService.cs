namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface INaturalPersonAgeProductSelectorsService
{
    Task<List<int?>> GetProducts(int age, int councilZoningID);
}
