namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class AgeOfNaturalPersonProductSelectorCrudService : IAgeOfNaturalPersonProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public AgeOfNaturalPersonProductSelectorCrudService(IApplicationDbContext context,
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
        var ageOfNaturalPersonProductSelectorDto = JsonConvert.DeserializeObject<AgeOfNaturalPersonProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.NaturalPersonAgeProductSelectors.Where(npaps => npaps.NaturalPersonAgeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            npaps.NaturalPersonAgeProductSelector_ProductID == ageOfNaturalPersonProductSelectorDto.Product.Key &&
                                            npaps.MinimumAge == ageOfNaturalPersonProductSelectorDto.MinimumAge &&
                                            npaps.MaximumAge == ageOfNaturalPersonProductSelectorDto.MaximumAge)
                                .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{ageOfNaturalPersonProductSelectorDto.Product.Value}"); }

        var naturalPersonAgeProductSelector = new NaturalPersonAgeProductSelector()
        {
            NaturalPersonAgeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            MaximumAge = ageOfNaturalPersonProductSelectorDto.MaximumAge,
            MinimumAge = ageOfNaturalPersonProductSelectorDto.MinimumAge,
            NaturalPersonAgeProductSelector_ProductID = ageOfNaturalPersonProductSelectorDto.Product.Key
        };

        await _context.NaturalPersonAgeProductSelectors.AddAsync(naturalPersonAgeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<NaturalPersonAgeProductSelector>(request.RuleID);

        return existingRule.NaturalPersonAgeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(NaturalPersonAgeProductSelector))
            : await _entityService.Delete<NaturalPersonAgeProductSelector>(request.RuleID);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.NaturalPersonAgeProductSelectors.Where(dps => dps.NaturalPersonAgeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID)
                   .Select(x => new AgeOfNaturalPersonProductSelectorDto()
                   {
                       ID = x.ID,
                       MinimumAge = x.MinimumAge,
                       MaximumAge = x.MaximumAge,
                       Product = new TextValuePair()
                       {
                           Key = x.NaturalPersonAgeProductSelector_ProductID != null ? (int)x.NaturalPersonAgeProductSelector_ProductID : 0,
                           Value = x.NaturalPersonAgeProductSelector_Product != null ? x.NaturalPersonAgeProductSelector_Product.Name : string.Empty,
                       }
                   }).ToListAsync();

        var resultWrapper = new CollectionResult<AgeOfNaturalPersonProductSelectorDto>()
        {
            FilterName = "Age of natural person(s)",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<AgeOfNaturalPersonProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.NaturalPersonAgeProductSelectors.Where(npps => npps.ID == toBeUpdatedRule.ID &&
                                                                                npps.NaturalPersonAgeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(NaturalPersonAgeProductSelector));

        if (toBeUpdatedRule.Product is null)
        {
            existingRule.NaturalPersonAgeProductSelector_ProductID = null;
        }
        else
        {
            if (existingRule.NaturalPersonAgeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
            {
                existingRule.NaturalPersonAgeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
            }
        }

        _mapper.Map(toBeUpdatedRule, existingRule);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
