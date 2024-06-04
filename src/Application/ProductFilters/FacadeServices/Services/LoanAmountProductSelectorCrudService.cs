namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class LoanAmountProductSelectorCrudService : ILoanAmountProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public LoanAmountProductSelectorCrudService(IApplicationDbContext context,
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
        var loanAmountSelector = JsonConvert.DeserializeObject<LoanAmountProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var doctype = await _entityService.GetByName<DocType>(loanAmountSelector.DocType);

        var existingEntry = await _context.LoanAmountProductSelectors.Where(laps => laps.LoanAmountProductSelector_DocTypeID == doctype.ID &&
                                            laps.LoanType != null && laps.LoanType.Replace(" ", "").ToLower() == loanAmountSelector.LoanType.Replace(" ", "").ToLower() &&
                                            laps.LoanAmountProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID).FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{loanAmountSelector.Product.Value}"); }

        var loanAmountProductSelector = new LoanAmountProductSelector()
        {
            LoanAmountProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            LoanAmountProductSelector_ProductID = loanAmountSelector.Product.Key,
            LoanAmountProductSelector_DocTypeID = doctype.ID,
            LoanType = loanAmountSelector.LoanType,
        };

        await _context.LoanAmountProductSelectors.AddAsync(loanAmountProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.LoanAmountProductSelectors.Where(dps => dps.LoanAmountProductSelector_CouncilZoningTypeID == request.CouncilZoiningID)
                    .Select(x => new LoanAmountProductSelectorDto()
                    {
                        ID = x.ID,
                        LoanType = x.LoanType ?? "",
                        DocType = x.LoanAmountProductSelector_DocType != null ? x.LoanAmountProductSelector_DocType.Name : "",
                        Product = new TextValuePair()
                        {
                            Key = x.LoanAmountProductSelector_ProductID != null ? (int)x.LoanAmountProductSelector_ProductID : 0,
                            Value = x.LoanAmountProductSelector_Product != null ? x.LoanAmountProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<LoanAmountProductSelectorDto>()
        {
            FilterName = "Loan Amount",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<LoanAmountProductSelector>(request.RuleID);

        return existingRule.LoanAmountProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(LoanAmountProductSelector))
            : await _entityService.Delete<LoanAmountProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<LoanAmountProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.LoanAmountProductSelectors.Where(npps => npps.ID == toBeUpdatedRule.ID &&
                                                                                npps.LoanAmountProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(LoanAmountProductSelector));

        if (existingRule.LoanAmountProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.LoanAmountProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        _mapper.Map(toBeUpdatedRule, existingRule);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
