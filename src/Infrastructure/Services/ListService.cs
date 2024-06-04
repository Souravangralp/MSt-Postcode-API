using ProductMatrix.Infrastructure.Data;

namespace ProductMatrix.Infrastructure.Services;

public class ListService : IListService
{
    #region Fields

    private readonly ApplicationDbContext _context;

    #endregion

    #region Ctor

    public ListService(ApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> GetAll<T>() where T : class 
    {
        var query = _context.Set<T>()
                    .AsNoTracking()
                    .Where(x => EF.Property<bool>(x, "ISDeleted") == false)
                    .Select(entity => new TextValuePair
                    { 
                        Key = EF.Property<int>(entity, "ID"),
                        Value = EF.Property<string>(entity, "Name"),
                    });

        return await query.ToArrayAsync();
    }

    #endregion
}
