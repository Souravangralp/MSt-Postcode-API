using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class AnnualFacilityFeeService : IAnnualFacilityFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public AnnualFacilityFeeService(IApplicationDbContext context,
        IGetDefaultFeeService getDefaultFeeService,
        IEntityService entityService)
    {
        _context = context;
        _getDefaultFeeService = getDefaultFeeService;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<double> CalculateAnnualFacilityFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var annualFacilityFee = await _context.DefaultFees.Where(x => x.DefaultFee_DocTypeID == docTypeId &&
                                                                      x.DefaultFee_ProductID == productFeeDto.ProductId)
                                                          .Select(x => x.AnnualFee)
                                                          .FirstOrDefaultAsync();

        annualFacilityFee *= (await _getDefaultFeeService.GetFee(FeeType.AnnualFacilityFee.FeeName, formulaType, docTypeId ?? 0) / 100);

        return annualFacilityFee ?? 0.0;
    }

    #region Helpers

    #endregion

    #endregion
}
