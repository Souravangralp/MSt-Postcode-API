using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class UsageTypeProductSelectorServiceCurdService : IUsageTypeProductSelectorServiceCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public UsageTypeProductSelectorServiceCurdService(IApplicationDbContext context,
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
        var usageTypeDto = JsonConvert.DeserializeObject<UsageTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.SecondaryUsageType, usageTypeDto.UsageType);

        var existingEntry = await _context.UsageTypeProductSelectors.Where(utps => utps.UsageTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      utps.UsageTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       utps.UsageTypeProductSelector_ProductID == usageTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{usageTypeDto.Product.Value}"); }

        var usageTypeProductSelector = new UsageTypeProductSelector()
        {
            UsageTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            UsageTypeProductSelector_ProductID = usageTypeDto.Product.Key,
            UsageTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.UsageTypeProductSelectors.AddAsync(usageTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.UsageTypeProductSelectors.Where(utps => utps.UsageTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !utps.ISDeleted)
                    .Select(x => new UsageTypeDto()
                    {
                        ID = x.ID,
                        UsageType = x.UsageTypeProductSelector_GeneralLookUp != null ? x.UsageTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.UsageTypeProductSelector_ProductID != null ? (int)x.UsageTypeProductSelector_ProductID : 0,
                            Value = x.UsageTypeProductSelector_Product != null ? x.UsageTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<UsageTypeDto>()
        {
            FilterName = "Usage Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<UsageTypeProductSelector>(request.RuleID);

        return existingRule.UsageTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(UsageTypeProductSelector))
            : await _entityService.Delete<UsageTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<UsageTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.UsageTypeProductSelectors.Where(utps => utps.ID == toBeUpdatedRule.ID &&
                                                                                utps.UsageTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(UsageTypeProductSelector));

        if (existingRule.UsageTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.UsageTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
