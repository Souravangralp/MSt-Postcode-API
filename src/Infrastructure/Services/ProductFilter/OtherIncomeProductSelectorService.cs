using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class OtherIncomeProductSelectorService : IOtherIncomeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public OtherIncomeProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string incomeType)
    {
        var otherIncomeType = await _context.OtherIncomeTypes.Where(oit => oit.Value.Replace(" ", "").ToLower() == incomeType.Replace(" ", "").ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync() ?? throw new NotFoundException(incomeType, nameof(OtherIncomeType));

        return await _context.OtherIncomeTypeProductSelectors.Where(oitps => oitps.OtherIncomeTypeProductSelector_OtherIncomeTypeID == otherIncomeType.ID)
            .AsNoTracking()
            .Select(oitps => oitps.OtherIncomeTypeProductSelector_ProductID)
            .ToListAsync();
    }

    #endregion
}
