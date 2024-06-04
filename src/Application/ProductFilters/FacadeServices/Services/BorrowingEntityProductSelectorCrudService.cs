namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class BorrowingEntityProductSelectorCrudService : IBorrowingEntityProductSelectorCrudService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public BorrowingEntityProductSelectorCrudService(IApplicationDbContext context,
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
        var borrowingEntityProductSelectorDto = JsonConvert.DeserializeObject<BorrowingEntityProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var borrowingEntityType = await _entityService.GetByName<BorrowingEntityType>(borrowingEntityProductSelectorDto.BorrowingEntity);

        var existingEntry = await _context.BorrowingEntityProductSelectors.Where(beps => beps.BorrowingEntityProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                            beps.BorrowingEntityProductSelector_ProductID == borrowingEntityProductSelectorDto.Product.Key &&
                                            beps.BorrowingEntityProductSelector_BorrowingEntityTypeID == borrowingEntityType.ID && !beps.ISDeleted)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{borrowingEntityProductSelectorDto.Product.Value}"); }

        var borrowingEntityProductSelector = new BorrowingEntityProductSelector()
        {
            BorrowingEntityProductSelector_ProductID = borrowingEntityProductSelectorDto.Product.Key,
            BorrowingEntityProductSelector_BorrowingEntityTypeID = borrowingEntityType.ID,
            BorrowingEntityProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID
        };

        await _context.BorrowingEntityProductSelectors.AddAsync(borrowingEntityProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<BorrowingEntityProductSelector>(request.RuleID);

        return existingRule.BorrowingEntityProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(BorrowingEntityProductSelector))
            : await _entityService.Delete<BorrowingEntityProductSelector>(request.RuleID);
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.BorrowingEntityProductSelectors.Where(dps => dps.BorrowingEntityProductSelector_CouncilZoningTypeID == request.CouncilZoiningID)
                    .Select(x => new BorrowingEntityProductSelectorDto()
                    {
                        ID = x.ID,
                        BorrowingEntity = x.BorrowingEntityProductSelector_BorrowingEntityType != null ? x.BorrowingEntityProductSelector_BorrowingEntityType.Name : string.Empty,
                        Product = new TextValuePair()
                        {
                            Key = x.BorrowingEntityProductSelector_ProductID != null ? (int)x.BorrowingEntityProductSelector_ProductID : 0,
                            Value = x.BorrowingEntityProductSelector_Product != null ? x.BorrowingEntityProductSelector_Product.Name : string.Empty,
                        }
                    }).OrderBy(x => x.Product.Key).ToListAsync();

        var resultWrapper = new CollectionResult<BorrowingEntityProductSelectorDto>()
        {
            FilterName = "Borrowing Entity",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<BorrowingEntityProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.BorrowingEntityProductSelectors.Where(dtps => dtps.ID == toBeUpdatedRule.ID &&
                                                                                dtps.BorrowingEntityProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(DocTypeProductSelector));

        if (existingRule.BorrowingEntityProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.BorrowingEntityProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        _mapper.Map(toBeUpdatedRule, existingRule);

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
