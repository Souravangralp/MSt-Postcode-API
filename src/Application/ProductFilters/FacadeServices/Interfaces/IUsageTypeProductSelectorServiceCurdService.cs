namespace ProductMatrix.Application.ProductFilters.FacadeServices.Interfaces;

public interface IUsageTypeProductSelectorServiceCurdService
{
    Task<bool> Create(CreateRuleCommand request);

    Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request);

    Task<bool> Delete(DeleteRuleCommand request);

    Task<bool> Update(UpdateRuleCommand request);
}
