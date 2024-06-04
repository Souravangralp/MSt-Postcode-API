namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class DocTypeProductSelectorService : IDocTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public DocTypeProductSelectorService(
        IApplicationDbContext context,
        IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string docType, int loanTermInYears, int councilZoningID)
    {
        int? docTypeID = _entityService.GetByName<DocType>(docType).Result.ID;

        return await _context.DocTypeProductSelectors.Where(dtps => dtps.DocTypeProductSelector_DocTypeID == docTypeID &&
                                                                    dtps.MinimumLoanTermInYears < loanTermInYears && 
                                                                    dtps.MaximumLoanTermInYears >= loanTermInYears &&
                                                                    dtps.DocTypeProductSelector_CouncilZoningTypeID == councilZoningID)
                                                     .AsNoTracking()
                                                     .Select(dtps => dtps.DocTypeProductSelector_ProductID)
                                                     .ToListAsync();        
    }

    #endregion
}
