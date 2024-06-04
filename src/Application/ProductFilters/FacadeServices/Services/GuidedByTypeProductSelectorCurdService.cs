using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class GuidedByTypeProductSelectorCurdService : IGuidedByTypeProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public GuidedByTypeProductSelectorCurdService(IApplicationDbContext context,
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
        var guidedByTypeDto = JsonConvert.DeserializeObject<GuidedByTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.GuidedByType, guidedByTypeDto.GuidedByType);

        var existingEntry = await _context.GuidedByTypeProductSelectors.Where(gtps => gtps.GuidedByTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      gtps.GuidedByTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       gtps.GuidedByTypeProductSelector_ProductID == guidedByTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{guidedByTypeDto.Product.Value}"); }

        var guidedByTypeProductSelector = new GuidedByTypeProductSelector()
        {
            GuidedByTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            GuidedByTypeProductSelector_ProductID = guidedByTypeDto.Product.Key,
            GuidedByTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.GuidedByTypeProductSelectors.AddAsync(guidedByTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.GuidedByTypeProductSelectors.Where(gtps => gtps.GuidedByTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !gtps.ISDeleted)
                    .Select(x => new GuidedByTypeDto()
                    {
                        ID = x.ID,
                        GuidedByType = x.GuidedByTypeProductSelector_GeneralLookUp != null ? x.GuidedByTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.GuidedByTypeProductSelector_ProductID != null ? (int)x.GuidedByTypeProductSelector_ProductID : 0,
                            Value = x.GuidedByTypeProductSelector_Product != null ? x.GuidedByTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<GuidedByTypeDto>()
        {
            FilterName = "Guided By Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<GuidedByTypeProductSelector>(request.RuleID);

        return existingRule.GuidedByTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(GuidedByTypeProductSelector))
            : await _entityService.Delete<GuidedByTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<GuidedByTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.GuidedByTypeProductSelectors.Where(gtps => gtps.ID == toBeUpdatedRule.ID &&
                                                                                gtps.GuidedByTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(GuidedByTypeProductSelector));

        if (existingRule.GuidedByTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.GuidedByTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
