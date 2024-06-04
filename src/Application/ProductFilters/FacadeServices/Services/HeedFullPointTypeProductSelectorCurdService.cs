using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class HeedFullPointTypeProductSelectorCurdService : IHeedFullPointTypeProductSelectorCurdService
{

    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public HeedFullPointTypeProductSelectorCurdService(IApplicationDbContext context,
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
        var heedFullPointTypeDto = JsonConvert.DeserializeObject<HeedFullPointTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.HeedfulPointsType, heedFullPointTypeDto.HeedFullPointType);

        var existingEntry = await _context.HeedFullPointTypeProductSelectors.Where(hptps => hptps.HeedFullPointTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      hptps.HeedFullPointTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       hptps.HeedFullPointTypeProductSelector_ProductID == heedFullPointTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{heedFullPointTypeDto.Product.Value}"); }

        var heedFullPointTypeProductSelector = new HeedFullPointTypeProductSelector()
        {
            HeedFullPointTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            HeedFullPointTypeProductSelector_ProductID = heedFullPointTypeDto.Product.Key,
            HeedFullPointTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.HeedFullPointTypeProductSelectors.AddAsync(heedFullPointTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.HeedFullPointTypeProductSelectors.Where(hptps => hptps.HeedFullPointTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !hptps.ISDeleted)
                    .Select(x => new HeedFullPointTypeDto()
                    {
                        ID = x.ID,
                        HeedFullPointType = x.HeedFullPointTypeProductSelector_GeneralLookUp != null ? x.HeedFullPointTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.HeedFullPointTypeProductSelector_ProductID != null ? (int)x.HeedFullPointTypeProductSelector_ProductID : 0,
                            Value = x.HeedFullPointTypeProductSelector_Product != null ? x.HeedFullPointTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<HeedFullPointTypeDto>()
        {
            FilterName = "Heedful Point",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<HeedFullPointTypeProductSelector>(request.RuleID);

        return existingRule.HeedFullPointTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(HeedFullPointTypeProductSelector))
            : await _entityService.Delete<HeedFullPointTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<HeedFullPointTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.HeedFullPointTypeProductSelectors.Where(hptps => hptps.ID == toBeUpdatedRule.ID &&
                                                                                hptps.HeedFullPointTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(HeedFullPointTypeProductSelector));

        if (existingRule.HeedFullPointTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.HeedFullPointTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
