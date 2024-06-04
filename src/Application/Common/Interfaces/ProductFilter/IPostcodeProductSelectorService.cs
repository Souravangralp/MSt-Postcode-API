namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IPostcodeProductSelectorService
{
    Task<List<int?>> GetProducts(string postcode, string? stateCode,string? suburb);
}
