namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class RenovationProductSelectorCrudService : IRenovationProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public RenovationProductSelectorCrudService(IApplicationDbContext context,
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
        return await CreateHelper(request, 2);
    }

    public async Task<bool> CreateStructuralChanges(CreateRuleCommand request)
    {
        return await CreateHelper(request, 1);
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        return await DeleteHelper(request, 2);
    }

    public async Task<bool> DeleteStructuralChanges(DeleteRuleCommand request)
    {
        return await DeleteHelper(request, 1);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        return await GetAllHelper(request, 2);
    }

    public async Task<ICollectionResult> GetAllStructuralChanges(GetAllRulesWithFilterIDQuery request)
    {
        return await GetAllHelper(request, 1);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        return await UpdateHelper(request, toBeUpdatedRule, 2);
    }

    public async Task<bool> UpdateStructuralChanges(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        return await UpdateHelper(request, toBeUpdatedRule, 1);
    }

    #region Helpers

    private async Task<bool> CreateHelper(CreateRuleCommand request, int renovationTypeId)
    {
        var constructionProductSelectorDto = JsonConvert.DeserializeObject<Common.Models.ProductFilters.ConstructionProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.ConstructionProductSelectors.Where(cps => cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            cps.ConstructionProductSelector_ConstructionTypeID == constructionProductSelectorDto.ConstructionTypeID &&
                                            cps.ConstructionProductSelector_BuilderTypeID == constructionProductSelectorDto.BuilderTypeID &&
                                            cps.ISGreenRated == false &&
                                            cps.ConstructionProductSelector_RenovationTypeID == renovationTypeId &&
                                            cps.ConstructionProductSelector_ProductID == constructionProductSelectorDto.Product.Key)
            .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{constructionProductSelectorDto.Product.Value}"); }

        var renovationProductSelector = new ConstructionProductSelector()
        {
            ConstructionProductSelector_RenovationTypeID = renovationTypeId,
            ConstructionProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ConstructionProductSelector_BuilderTypeID = constructionProductSelectorDto.BuilderTypeID,
            ConstructionProductSelector_ConstructionTypeID = constructionProductSelectorDto.ConstructionTypeID,
            ConstructionProductSelector_ProductID = constructionProductSelectorDto.Product.Key,
            ISGreenRated = false,
        };

        await _context.ConstructionProductSelectors.AddAsync(renovationProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    private async Task<bool> DeleteHelper(DeleteRuleCommand request, int renovationTypeId)
    {
        var existingRule = await _entityService.Get<ConstructionProductSelector>(request.RuleID);

        return existingRule.ConstructionProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(DocTypeProductSelector))
            : await _entityService.Delete<ConstructionProductSelector>(request.RuleID);
    }

    private async Task<ICollectionResult> GetAllHelper(GetAllRulesWithFilterIDQuery request, int renovationTypeId)
    {
        var duplicateProducts = await GetConstructionRenovationProducts(request, renovationTypeId);

        var resultWrapper = new CollectionResult<Application.Common.Models.ProductFilters.ConstructionProductSelectorDto>()
        {
            FilterName = "Renovation without structural changes",
            Collection = duplicateProducts
        };

        return resultWrapper;
    }

    private async Task<bool> UpdateHelper(UpdateRuleCommand request, Common.Models.ProductFilters.ConstructionProductSelectorDto toBeUpdatedRule, int renovationTypeId)
    {
        var existingRules = await _context.ConstructionProductSelectors.Where(cps => cps.ID == toBeUpdatedRule.ID &&
                                                                                cps.ConstructionProductSelector_RenovationTypeID == renovationTypeId &&
                                                                                cps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                cps.ConstructionProductSelector_ConstructionTypeID == toBeUpdatedRule.ConstructionTypeID &&
                                                                                cps.ConstructionProductSelector_BuilderTypeID == toBeUpdatedRule.BuilderTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ConstructionProductSelector));

        _mapper.Map(toBeUpdatedRule, existingRules);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    private async Task<List<Common.Models.ProductFilters.ConstructionProductSelectorDto>> GetConstructionRenovationProducts(GetAllRulesWithFilterIDQuery request, int? renovationId, bool isGreenRated = false)
    {
        var collection = await _context.ConstructionProductSelectors.Where(dps => dps.ConstructionProductSelector_CouncilZoningTypeID == request.CouncilZoiningID &&
                            dps.ConstructionProductSelector_RenovationTypeID == renovationId &&
                            dps.ISGreenRated == isGreenRated)
                            .Select(x => new Common.Models.ProductFilters.ConstructionProductSelectorDto()
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

    #endregion
}
