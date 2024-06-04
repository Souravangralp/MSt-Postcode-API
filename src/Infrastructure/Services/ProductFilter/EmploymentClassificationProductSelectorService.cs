namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class EmploymentClassificationProductSelectorService : IEmploymentClassificationProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public EmploymentClassificationProductSelectorService(
        IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string employmentStatusType, int experienceOfWorkInMonths, bool ISSameLineOfWork, int councilZoningID)
    {
        var employmentClassifications = await _context.EmploymentClassifications
                                                .Where(ec => ec.EmploymentStatusType.Replace(" ", "").ToLower() == employmentStatusType.Replace(" ", "").ToLower() &&
                                                             ec.MinimumExperienceOfWorkInMonths < experienceOfWorkInMonths &&
                                                             ec.MaximumExperienceOfWorkInMonths >= experienceOfWorkInMonths &&
                                                             ec.EmploymentClassification_CouncilZoningCategoryID == councilZoningID &&
                                                             ec.ISSameLineOfWork == ISSameLineOfWork)
                                                .Include(ec => ec.EmploymentClassificationProductSelectors)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();

        return employmentClassifications is not null
                                    ? employmentClassifications.EmploymentClassificationProductSelectors
                                                .Select(ecps => ecps.EmploymentClassificationProductSelector_ProductID).ToList()
                                    : [];
    }

    #endregion
}
