namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class ConstructionProductSelectorCrudService : IConstructionProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ConstructionProductSelectorCrudService(IApplicationDbContext context,
        IMapper mapper,
        IEntityService entityService)
    {
        _context = context;
        _mapper = mapper;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<bool> Create(CreateRuleCommand request)
    {
        var constructionProductSelectorDto = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.ConstructionProductSelectors.Where(cps => cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            cps.ConstructionProductSelector_ConstructionTypeID == constructionProductSelectorDto.ConstructionTypeID &&
                                            cps.ConstructionProductSelector_BuilderTypeID == constructionProductSelectorDto.BuilderTypeID &&
                                            cps.ISGreenRated == false &&
                                            cps.ConstructionProductSelector_ProductID == constructionProductSelectorDto.Product.Key)
            .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{constructionProductSelectorDto.Product.Value}"); }

        var constructionProductSelector = new ConstructionProductSelector()
        {
            ConstructionProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ConstructionProductSelector_BuilderTypeID = constructionProductSelectorDto.BuilderTypeID,
            ConstructionProductSelector_ConstructionTypeID = constructionProductSelectorDto.ConstructionTypeID,
            ConstructionProductSelector_ProductID = constructionProductSelectorDto.Product.Key,
            ISGreenRated = false,
        };

        await _context.ConstructionProductSelectors.AddAsync(constructionProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> CreateGreen(CreateRuleCommand request)
    {
        var constructionProductSelectorDto = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.ConstructionProductSelectors.Where(cps => cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            cps.ConstructionProductSelector_ConstructionTypeID == constructionProductSelectorDto.ConstructionTypeID &&
                                            cps.ConstructionProductSelector_BuilderTypeID == constructionProductSelectorDto.BuilderTypeID &&
                                            cps.ISGreenRated == true &&
                                            cps.ConstructionProductSelector_ProductID == constructionProductSelectorDto.Product.Key)
            .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{constructionProductSelectorDto.Product.Value}"); }

        var constructionProductSelector = new ConstructionProductSelector()
        {
            ConstructionProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ConstructionProductSelector_BuilderTypeID = constructionProductSelectorDto.BuilderTypeID,
            ConstructionProductSelector_ConstructionTypeID = constructionProductSelectorDto.ConstructionTypeID,
            ConstructionProductSelector_ProductID = constructionProductSelectorDto.Product.Key,
            ISGreenRated = true,
        };

        await _context.ConstructionProductSelectors.AddAsync(constructionProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<ConstructionProductSelector>(request.RuleID);

        return existingRule.ConstructionProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(ConstructionProductSelector))
            : await _entityService.Delete<ConstructionProductSelector>(request.RuleID);
    }

    public async Task<bool> DeleteGreen(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<ConstructionProductSelector>(request.RuleID);

        return existingRule.ConstructionProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(ConstructionProductSelector))
            : await _entityService.Delete<ConstructionProductSelector>(request.RuleID);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var duplicateProducts = await GetConstructionRenovationProducts(request, null);

        var resultWrapper = new CollectionResult<Common.Models.ProductFilters.ConstructionProductSelectorDto>()
        {
            FilterName = "Construction",
            Collection = duplicateProducts
        };

        return resultWrapper;
    }

    public async Task<ICollectionResult> GetAllGreen(GetAllRulesWithFilterIDQuery request)
    {
        var duplicateProducts = await GetConstructionRenovationProducts(request, null, true);

        var resultWrapper = new CollectionResult<Common.Models.ProductFilters.ConstructionProductSelectorDto>()
        {
            FilterName = "Construction Green",
            Collection = duplicateProducts
        };

        return resultWrapper;
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRules = await _context.ConstructionProductSelectors.Where(cps => cps.ID == toBeUpdatedRule.ID &&
                                                                                cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                cps.ConstructionProductSelector_ConstructionTypeID == toBeUpdatedRule.ConstructionTypeID &&
                                                                                cps.ConstructionProductSelector_BuilderTypeID == toBeUpdatedRule.BuilderTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ConstructionProductSelector));

        _mapper.Map(toBeUpdatedRule, existingRules);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateGreen(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRules = await _context.ConstructionProductSelectors.Where(cps => cps.ID == toBeUpdatedRule.ID &&
                                                                                cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                cps.ConstructionProductSelector_ConstructionTypeID == toBeUpdatedRule.ConstructionTypeID &&
                                                                                cps.ConstructionProductSelector_BuilderTypeID == toBeUpdatedRule.BuilderTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ConstructionProductSelector));

        _mapper.Map(toBeUpdatedRule, existingRules);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion

    #region Helpers

    private async Task<List<Application.Common.Models.ProductFilters.ConstructionProductSelectorDto>> GetConstructionRenovationProducts(GetAllRulesWithFilterIDQuery request, int? renovationId, bool isGreenRated = false)
    {
        var collection = await _context.ConstructionProductSelectors.Where(dps => dps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoiningID &&
                            dps.ConstructionProductSelector_RenovationTypeID == renovationId &&
                            dps.ISGreenRated == isGreenRated)
                            .Select(x => new Application.Common.Models.ProductFilters.ConstructionProductSelectorDto()
                            {
                                ID = x.ID,
                                Rule = string.Format((x.ConstructionProductSelector_ConstructionType != null ?
                                            x.ConstructionProductSelector_ConstructionType.Value : "") + " " +
                                            (x.ConstructionProductSelector_BuilderType != null ?
                                            x.ConstructionProductSelector_BuilderType.Value : "")),
                                Product = new TextValuePair()
                                {
                                    Key = x.ConstructionProductSelector_ProductID != null ? (int)x.ConstructionProductSelector_ProductID : 0,
                                    Value = x.ConstructionProductSelector_Product != null ? x.ConstructionProductSelector_Product.Name : string.Empty,
                                }
                            }).OrderBy(x => x.Product.Key).ToListAsync();


        return collection;
    }

    #endregion
}
