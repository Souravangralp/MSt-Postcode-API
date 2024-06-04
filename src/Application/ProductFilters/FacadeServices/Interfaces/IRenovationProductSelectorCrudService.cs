namespace ProductMatrix.Application.ProductFilters.FacadeServices.Interfaces;

public interface IRenovationProductSelectorCrudService 
{
    Task<bool> Create(CreateRuleCommand request);

    Task<bool> CreateStructuralChanges(CreateRuleCommand request);

    Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request);

    Task<ICollectionResult> GetAllStructuralChanges(GetAllRulesWithFilterIDQuery request);

    Task<bool> Update(UpdateRuleCommand request);

    Task<bool> UpdateStructuralChanges(UpdateRuleCommand request);

    Task<bool> Delete(DeleteRuleCommand request);

    Task<bool> DeleteStructuralChanges(DeleteRuleCommand request);
}
