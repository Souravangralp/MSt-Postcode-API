namespace ProductMatrix.Application.ProductFilters.FacadeServices.Interfaces;

public interface IConstructionProductSelectorCrudService
{
    Task<bool> Create(CreateRuleCommand request);

    Task<bool> CreateGreen(CreateRuleCommand request);

    Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request);

    Task<ICollectionResult> GetAllGreen(GetAllRulesWithFilterIDQuery request);

    Task<bool> Update(UpdateRuleCommand request);

    Task<bool> UpdateGreen(UpdateRuleCommand request);

    Task<bool> Delete(DeleteRuleCommand request);

    Task<bool> DeleteGreen(DeleteRuleCommand request);
}
