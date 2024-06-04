namespace ProductMatrix.Infrastructure.Services;

public class GeneralLookUpService : IGeneralLookUpService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public GeneralLookUpService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<GeneralLookUp> Create(string type, string value)
    {
        await GetGeneralLookUpID(type, value);

        GeneralLookUp generalLookUp = new() { Type = type, Value = value };

        await _context.GeneralLookUps.AddAsync(generalLookUp);

        await _context.SaveChangesAsync(CancellationToken.None);

        return generalLookUp;
    }

    public async Task<GeneralLookUp> Update(int id, string type, string value)
    {
        GeneralLookUp generalLookUp = new() { ID = id, Type = type, Value = value };

        _context.GeneralLookUps.Update(generalLookUp);

        await _context.SaveChangesAsync(CancellationToken.None);

        return generalLookUp;
    }

    public async Task<int> GetGeneralLookUpID(string type, string value)
    {
        var generalLookUp = await _context.GeneralLookUps.Where(glu => glu.Type.Replace(" ", "").ToLower() == type.Replace(" ", "").ToLower() &&
                                                                                 glu.Value.Replace(" ", "").ToLower() == value.Replace(" ", "").ToLower())
                                                                   .FirstOrDefaultAsync() ?? throw new NotFoundException(value, nameof(GeneralLookUp));

        return generalLookUp.ID;
    }

    #endregion
}
