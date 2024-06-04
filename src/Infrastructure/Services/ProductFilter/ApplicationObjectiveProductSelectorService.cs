namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ApplicationObjectiveProductSelectorService : IApplicationObjectiveProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public ApplicationObjectiveProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string equityType, string usageType, string? awayBankType, int consolidateLoan, int councilZoningId)
    {
        int? awayBankTypeGeneralLookUpId = null;
        var equityTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.EquityType, equityType);
        var usageTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.UsageType, usageType);

        if(!string.IsNullOrWhiteSpace(awayBankType))
              awayBankTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.AwayBankType, awayBankType);

        var applicationObjectiveClassification = await _context.ApplicationObjectiveClassifications
                                                .Where(aoc => aoc.EquityType_GeneralLookUpID == equityTypeGeneralLookUpId &&
                                                              aoc.UsageType_GeneralLookUpID == usageTypeGeneralLookUpId &&
                                                              aoc.AwayBankType_GeneralLookUpID == awayBankTypeGeneralLookUpId &&
                                                              aoc.ConsolidateForm <= consolidateLoan &&
                                                              aoc.ConsolidateTo > consolidateLoan &&
                                                              aoc.ApplicationObjectiveClassification_CouncilZoningTypeID == councilZoningId)
                                                .FirstOrDefaultAsync() ?? throw new NotFoundException(equityType + " " + usageType + " " + awayBankType, nameof(ApplicationObjectiveClassification));

        return await _context.ApplicationObjectiveProductSelectors
                                            .Where(aops => aops.ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID == applicationObjectiveClassification.ID)
                                            .Select(aops => aops.ApplicationObjectiveProductSelector_ProductID)
                                            .ToListAsync();
    }

    #endregion
}
