namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class DwellingProductSelectorCurdService : IDwellingProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public DwellingProductSelectorCurdService(IApplicationDbContext context,
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
        var dwellingProductSelectorDto = JsonConvert.DeserializeObject<DwellingProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.DwellingsProductSelectors
                                        .Where(dps => dps.PCCategory.Replace(" ","").ToLower() == dwellingProductSelectorDto.PCCategory.Replace(" ","").ToLower() &&
                                                      dps.DwellingCount == dwellingProductSelectorDto.DwellingCount &&
                                                      dps.DwellingsProductSelector_CouncilZoningCategoryTypeID == request.CouncilZoningTypeID &&
                                                      dps.DwellingsProductSelector_ProductID == dwellingProductSelectorDto.Product.Key)
                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{dwellingProductSelectorDto.Product.Value}"); }

        var dwellingsProductSelector = new DwellingsProductSelector()
        {
            PCCategory = dwellingProductSelectorDto.PCCategory,
            DwellingCount = dwellingProductSelectorDto.DwellingCount,
            DwellingsProductSelector_CouncilZoningCategoryTypeID = request.CouncilZoningTypeID,
            DwellingsProductSelector_ProductID = dwellingProductSelectorDto.Product.Key
        };

        await _context.DwellingsProductSelectors.AddAsync(dwellingsProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.DwellingsProductSelectors.Where(dps => dps.DwellingsProductSelector_CouncilZoningCategoryTypeID == request.CouncilZoiningID
                                                                                   && !dps.ISDeleted)
                    .Select(dps => new DwellingProductSelectorDto()
                    {
                        ID = dps.ID,
                        PCCategory = dps.PCCategory,
                        DwellingCount = dps.DwellingCount,
                        Product = new TextValuePair()
                        {
                            Key = dps.DwellingsProductSelector_ProductID != null ? (int)dps.DwellingsProductSelector_ProductID : 0,
                            Value = dps.DwellingsProductSelector_Product != null ? dps.DwellingsProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<DwellingProductSelectorDto>()
        {
            FilterName = "Dwelling Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<DwellingsProductSelector>(request.RuleID);

        return existingRule.DwellingsProductSelector_CouncilZoningCategoryTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(DwellingsProductSelector))
            : await _entityService.Delete<DwellingsProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<DwellingProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.DwellingsProductSelectors.Where(gtps => gtps.ID == toBeUpdatedRule.ID &&
                                                                                gtps.DwellingsProductSelector_CouncilZoningCategoryTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(DwellingsProductSelector));

        if (existingRule.DwellingsProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.DwellingsProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
