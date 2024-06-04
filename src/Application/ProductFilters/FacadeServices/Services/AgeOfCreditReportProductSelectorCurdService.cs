namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class AgeOfCreditReportProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public AgeOfCreditReportProductSelectorCurdService(IApplicationDbContext context,
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
        var ageOfCreditProductSelectorDto = JsonConvert.DeserializeObject<AgeOfCreditReportDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingEntry = await _context.AgeCreditReportProductSelectors.Where(acrps => acrps.FromDays == ageOfCreditProductSelectorDto.FromDays &&
                                            acrps.ToDays == ageOfCreditProductSelectorDto.ToDays &&
                                            acrps.AgeCreditReportProductSelector_ProductID == ageOfCreditProductSelectorDto.Product.Key).FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{ageOfCreditProductSelectorDto.Product.Value}"); }

        var ageCreditReportProductSelector = new AgeCreditReportProductSelector()
        {
            AgeCreditReportProductSelector_ProductID = ageOfCreditProductSelectorDto.Product.Key,
            FromDays = ageOfCreditProductSelectorDto.FromDays,
            ToDays = ageOfCreditProductSelectorDto.ToDays
        };

        await _context.AgeCreditReportProductSelectors.AddAsync(ageCreditReportProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        return await _entityService.Delete<AgeCreditReportProductSelector>(request.RuleID);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.DocTypeProductSelectors.Where(dps => dps.DocTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID && !dps.ISDeleted)
                    .Select(x => new DocTypeProductSelectorDto()
                    {
                        ID = x.ID,
                        DocType = x.DocTypeProductSelector_DocType != null ? x.DocTypeProductSelector_DocType.Name : string.Empty,
                        MinimumLoanTermInYears = x.MinimumLoanTermInYears,
                        MaximumLoanTermInYears = x.MaximumLoanTermInYears,
                        Product = new TextValuePair()
                        {
                            Key = x.DocTypeProductSelector_ProductID != null ? (int)x.DocTypeProductSelector_ProductID : 0,
                            Value = x.DocTypeProductSelector_Product != null ? x.DocTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).OrderBy(x => x.Product.Key).ToListAsync();

        var resultWrapper = new CollectionResult<DocTypeProductSelectorDto>()
        {
            FilterName = "Age of credit report",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<DocTypeProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.DocTypeProductSelectors.Where(dtps => dtps.ID == toBeUpdatedRule.ID &&
                                                                                dtps.DocTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(DocTypeProductSelector));

        if (toBeUpdatedRule.Product is null)
        {
            existingRule.DocTypeProductSelector_ProductID = null;
        }
        else
        {
            if (existingRule.DocTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
            {
                existingRule.DocTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
            }
        }

        _mapper.Map(toBeUpdatedRule, existingRule);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
