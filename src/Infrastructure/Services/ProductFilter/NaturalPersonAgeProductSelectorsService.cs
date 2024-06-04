namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class NaturalPersonAgeProductSelectorsService : INaturalPersonAgeProductSelectorsService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public NaturalPersonAgeProductSelectorsService(
        IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(int age, int councilZoningID)
    {
        return await _context.NaturalPersonAgeProductSelectors.Where(npaps => npaps.MinimumAge <= age &&
                                                                              npaps.MaximumAge >= age &&
                                                                              npaps.NaturalPersonAgeProductSelector_CouncilZoningTypeID == councilZoningID)
                                                             .AsNoTracking()
                                                             .Select(npaps => npaps.NaturalPersonAgeProductSelector_ProductID)                       
                                                             .ToListAsync();
    }

    #endregion
}
