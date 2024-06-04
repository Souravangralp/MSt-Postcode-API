namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class SelfEmployedClassificationProductSelectorService : ISelfEmployedClassificationProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public SelfEmployedClassificationProductSelectorService(
        IApplicationDbContext context, 
        IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string docType, int selfEmployedTimeInMonths)
    {
        int? docTypeId = _entityService.GetByName<DocType>(docType).Result.ID;

        var employmentClassifications = await _context.SelfEmployedClassifications
                                                .Where(sec => sec.SelfEmployedClassification_DocTypeID == docTypeId &&
                                                              sec.MinimumTimeInMonths < selfEmployedTimeInMonths &&
                                                              sec.MaximumTimeInMonths >= selfEmployedTimeInMonths)
                                                .Include(sec => sec.SelfEmployedClassificationProductSelectors)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync() ?? throw new NotFoundException("", "");

        return employmentClassifications.SelfEmployedClassificationProductSelectors.Select(secps => secps.SelfEmployedClassificationProductSelector_ProductID).ToList();
    }

    #endregion
}
