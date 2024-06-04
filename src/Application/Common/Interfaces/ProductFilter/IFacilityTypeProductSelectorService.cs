namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IFacilityTypeProductSelectorService
{
    Task<List<int?>> GetProducts(string facilityType);
}
