namespace ProductMatrix.Infrastructure.Services;

public class GetDefaultSetting : IGetDefaultSetting
{
    #region Fields

    private readonly IApplicationDbContext _context;
    
    #endregion

    #region Ctor

    public GetDefaultSetting(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<dynamic> GetByProperty(string property)
    {
        var setting = await _context.DefaultSettings.Where(defaultSetting => defaultSetting.Property.ToLower().Replace(" ", "") == property.ToLower().Replace(" ", ""))
            .FirstOrDefaultAsync() ?? throw new NotFoundException(property, nameof(DefaultSetting));

        return TypeConversionExtension.GetCastedValue(setting.DataType, setting.Value);
    }

    public async Task<string> GetByValue(string value)
    {
        return await _context.DefaultSettings.Where(defaultSetting => defaultSetting.Value.ToLower().Replace(" ", "") == value.ToLower().Replace(" ", ""))
            .Select(defaultSetting => defaultSetting.Property)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(value, nameof(DefaultSetting));
    }

    #endregion
}
