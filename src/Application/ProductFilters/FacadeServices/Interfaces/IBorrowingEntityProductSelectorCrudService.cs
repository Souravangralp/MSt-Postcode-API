namespace ProductMatrix.Application.ProductFilters.FacadeServices.Interfaces;

public interface IBorrowingEntityProductSelectorCrudService 
{
    Task<bool> Create(CreateRuleCommand request);

    Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request);

    Task<bool> Update(UpdateRuleCommand request);

    Task<bool> Delete(DeleteRuleCommand request);
}
