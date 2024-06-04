using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class ServiceTypeProductSelectorCurdService : IServiceTypeProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ServiceTypeProductSelectorCurdService(IApplicationDbContext context,
        IGeneralLookUpService generalLookUpService,
        IEntityService entityService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<bool> Create(CreateRuleCommand request)
    {
        var serviceTypeDto = JsonConvert.DeserializeObject<ServiceTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.ServiceType, serviceTypeDto.ServiceType);

        var existingEntry = await _context.ServiceTypeProductSelectors.Where(stps => stps.ServiceTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      stps.ServiceTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       stps.ServiceTypeProductSelector_ProductID == serviceTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{serviceTypeDto.Product.Value}"); }

        var serviceTypeProductSelector = new ServiceTypeProductSelector()
        {
            ServiceTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ServiceTypeProductSelector_ProductID = serviceTypeDto.Product.Key,
            ServiceTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.ServiceTypeProductSelectors.AddAsync(serviceTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.ServiceTypeProductSelectors.Where(stps => stps.ServiceTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !stps.ISDeleted)
                    .Select(x => new ServiceTypeDto()
                    {
                        ID = x.ID,
                        ServiceType = x.ServiceTypeProductSelector_GeneralLookUp != null ? x.ServiceTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.ServiceTypeProductSelector_ProductID != null ? (int)x.ServiceTypeProductSelector_ProductID : 0,
                            Value = x.ServiceTypeProductSelector_Product != null ? x.ServiceTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<ServiceTypeDto>()
        {
            FilterName = "Service Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<ServiceTypeProductSelector>(request.RuleID);

        return existingRule.ServiceTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(ServiceTypeProductSelector))
            : await _entityService.Delete<ServiceTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<ServiceTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.ServiceTypeProductSelectors.Where(stps => stps.ID == toBeUpdatedRule.ID &&
                                                                                stps.ServiceTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ServiceTypeProductSelector));

        if (existingRule.ServiceTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.ServiceTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
