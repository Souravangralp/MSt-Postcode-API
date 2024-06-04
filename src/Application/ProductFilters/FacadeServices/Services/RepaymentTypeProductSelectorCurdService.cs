namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class RepaymentTypeProductSelectorCurdService : IRepaymentTypeProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public RepaymentTypeProductSelectorCurdService(IApplicationDbContext context,
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
        var repaymentTypeDto = JsonConvert.DeserializeObject<RepaymentTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        repaymentTypeDto.RateType = repaymentTypeDto.RateType != null ? repaymentTypeDto.RateType : "";

        var existingEntry = await _context.RepaymentTypeProductSelectors
                        .Where(rtps => rtps.RepaymentType.Replace(" ","").ToLower() == repaymentTypeDto.RepaymentType.Replace(" ","").ToLower() &&
                                       rtps.RateType.Replace(" ", "").ToLower() == repaymentTypeDto.RateType.Replace(" ", "") &&
                                       rtps.TimeInYears == repaymentTypeDto.TimeInYears &&
                                       rtps.RepaymentTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                       rtps.RepaymentTypeProductSelector_ProductID == repaymentTypeDto.Product.Key)
                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{repaymentTypeDto.Product.Value}"); }

        var repaymentTypeProductSelector = new RepaymentTypeProductSelector()
        {
            RepaymentType = repaymentTypeDto.RepaymentType,
            RateType = repaymentTypeDto.RateType,
            TimeInYears = repaymentTypeDto.TimeInYears,
            RepaymentTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            RepaymentTypeProductSelector_ProductID = repaymentTypeDto.Product.Key
        };

        await _context.RepaymentTypeProductSelectors.AddAsync(repaymentTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.RepaymentTypeProductSelectors.Where(rtps => rtps.RepaymentTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !rtps.ISDeleted)
                    .Select(x => new RepaymentTypeDto()
                    {
                        ID = x.ID,
                        RepaymentType = x.RepaymentType,
                        RateType = x.RateType,
                        TimeInYears = x.TimeInYears,
                        Product = new TextValuePair()
                        {
                            Key = x.RepaymentTypeProductSelector_ProductID != null ? (int)x.RepaymentTypeProductSelector_ProductID : 0,
                            Value = x.RepaymentTypeProductSelector_Product != null ? x.RepaymentTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<RepaymentTypeDto>()
        {
            FilterName = "Facility Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<RepaymentTypeProductSelector>(request.RuleID);

        return existingRule.RepaymentTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(RepaymentTypeProductSelector))
            : await _entityService.Delete<RepaymentTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<RepaymentTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.RepaymentTypeProductSelectors.Where(npps => npps.ID == toBeUpdatedRule.ID &&
                                                                                npps.RepaymentTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString() ?? "", nameof(RepaymentTypeProductSelector));

        if (existingRule.RepaymentTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.RepaymentTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
