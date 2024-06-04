namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class LandSizeProductSelectorServiceCurdService : ILandSizeProductSelectorServiceCurdService
{

    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public LandSizeProductSelectorServiceCurdService(IApplicationDbContext context,
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
        var landSize = JsonConvert.DeserializeObject<LandSizeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var landSizeClassification = await _context.LandSizeClassifications
                                                .Where(ec => ec.From == landSize.LandSizeFrom &&
                                                             ec.To == landSize.LandSizeTo &&
                                                             ec.LandSizeClassification_CouncilZoningTypeID == request.CouncilZoningTypeID)
                                                .FirstOrDefaultAsync() ?? throw new NotFoundException(landSize.LandSizeFrom.ToString() ?? "", nameof(LandSize));

        var existingEntry = await _context.LandSizeProductSelectors
                                                    .Where(lsps => lsps.LandSizeProductSelector_LandSizeClassificationID == landSizeClassification.ID &&
                                                                   lsps.LandSizeProductSelector_ProductID == landSize.Product.Key)
                                                    .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{landSize.Product.Value}"); }

        var landSizeProductSelector = new LandSizeProductSelector()
        {
            LandSizeProductSelector_LandSizeClassificationID = landSizeClassification.ID,
            LandSizeProductSelector_ProductID = landSize.Product.Key
        };

        await _context.LandSizeProductSelectors.AddAsync(landSizeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = from lsc in _context.LandSizeClassifications
                         join lsps in _context.LandSizeProductSelectors on lsc.ID equals lsps.LandSizeProductSelector_LandSizeClassificationID                        
                         join p in _context.Products on lsps.LandSizeProductSelector_ProductID equals p.ID into pJoin
                         from p in pJoin.DefaultIfEmpty()
                         where !lsps.ISDeleted
                         select new LandSizeDto
                         {
                             ID = lsps.ID,
                             LandSizeFrom = lsc.From,
                             LandSizeTo = lsc.To,
                             Product = new TextValuePair { Key = p.ID, Value = p.Name }
                         };

        var resultWrapper = new CollectionResult<LandSizeDto>()
        {
            FilterName = "Land size",
            Collection = await collection.ToListAsync()
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        return await _entityService.Delete<LandSizeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<LandSizeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.LandSizeProductSelectors.Where(lsps => lsps.ID == toBeUpdatedRule.ID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString() ?? "", nameof(LandSizeProductSelector));

        if (existingRule.LandSizeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.LandSizeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
