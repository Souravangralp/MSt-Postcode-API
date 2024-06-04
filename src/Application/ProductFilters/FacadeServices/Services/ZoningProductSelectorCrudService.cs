namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class ZoningProductSelectorCrudService : IZoningProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ZoningProductSelectorCrudService(IApplicationDbContext context,
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
        var zoningProductSelectorDto = JsonConvert.DeserializeObject<ZoiningProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var council = await _entityService.GetByName<CouncilZoningCategory>(zoningProductSelectorDto.Council);

        var state = await _context.States.Where(s => s.Name.Replace(" ", "").Trim() == zoningProductSelectorDto.State.Replace(" ", "").Trim() ||
                                        s.AbbreivatedName.Replace(" ", "").Trim() == zoningProductSelectorDto.State.Replace(" ", "").Trim())
                            .AsNoTracking()
                            .FirstOrDefaultAsync() ?? throw new NotFoundException(zoningProductSelectorDto.State, nameof(State));

        var existingEntry = await _context.ZoningTypeProductSelectors.Where(ztps => ztps.ZoningTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            ztps.ZoningTypeProductSelector_CouncilZoningCategoryID == council.ID &&
                                            ztps.ZoningTypeProductSelector_ProductID == zoningProductSelectorDto.Product.Key &&
                                            ztps.ZoningTypeProductSelector_StateID == state.ID)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{zoningProductSelectorDto.Product.Value}"); }

        var zoningTypeProductSelector = new ZoningTypeProductSelector()
        {
            ZoningTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ZoningTypeProductSelector_CouncilZoningCategoryID = council.ID,
            ZoningTypeProductSelector_StateID = state.ID,
            Zone = zoningProductSelectorDto.Zone,
            ZoningTypeProductSelector_ProductID = zoningProductSelectorDto.Product.Key
        };

        await _context.ZoningTypeProductSelectors.AddAsync(zoningTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<ZoningTypeProductSelector>(request.RuleID);

        return existingRule.ZoningTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(ZoningTypeProductSelector))
            : await _entityService.Delete<ZoningTypeProductSelector>(request.RuleID);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.ZoningTypeProductSelectors.Where(dps => dps.ZoningTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID)
                   .Select(x => new ZoiningProductSelectorDto()
                   {
                       ID = x.ID,
                       Zone = x.Zone,
                       Council = x.ZoningTypeProductSelector_CouncilZoningCategory != null ? x.ZoningTypeProductSelector_CouncilZoningCategory.Name : string.Empty,
                       State = x.ZoningTypeProductSelector_State != null ? x.ZoningTypeProductSelector_State.Name : string.Empty,
                       Product = new TextValuePair()
                       {
                           Key = x.ZoningTypeProductSelector_ProductID != null ? (int)x.ZoningTypeProductSelector_ProductID : 0,
                           Value = x.ZoningTypeProductSelector_Product != null ? x.ZoningTypeProductSelector_Product.Name : string.Empty,
                       }
                   }).ToListAsync();

        var resultWrapper = new CollectionResult<ZoiningProductSelectorDto>()
        {
            FilterName = "Zoning",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<ZoiningProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var council = await _entityService.GetByName<CouncilZoningCategory>(toBeUpdatedRule.Council);

        var existingRule = await _context.ZoningTypeProductSelectors.Where(dtps => dtps.ID == toBeUpdatedRule.ID &&
                                                                                dtps.ZoningTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                dtps.ZoningTypeProductSelector_CouncilZoningCategoryID == council.ID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ZoningTypeProductSelector));

        if (toBeUpdatedRule.Product is null)
        {
            existingRule.ZoningTypeProductSelector_ProductID = null;
        }
        else
        {
            if (existingRule.ZoningTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
            {
                existingRule.ZoningTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
            }
        }

        _mapper.Map(toBeUpdatedRule, existingRule);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);


        throw new NotImplementedException();
    }

    #endregion
}
