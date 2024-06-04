namespace ProductMatrix.Application.Common.Interfaces.ProductFilter;

public interface IConstructionProductSelectorService
{
    Task<List<int?>> GetProducts(ProductMatrix.Application.Common.Models.ProductSelectors.ConstructionProductSelectorDto constructionProductSelectorDto);
}
