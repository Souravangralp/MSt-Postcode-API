using ProductMatrix.Infrastructure.Data;

namespace ProductMatrix.Infrastructure.Services;

public class EntityService : IEntityService
{
    #region Fields

    private readonly ApplicationDbContext _context;

    #endregion

    #region Ctor

    public EntityService(ApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<T> Get<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id);

        return entity == null ? throw new NotFoundException(id.ToString(), typeof(T).Name) : entity;
    }

    public async Task<T> GetByName<T>(string name) where T : class
    {
        var entity = await _context.Set<T>()
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => EF.Property<string>(x, "Name").Replace(" ", "").ToLower() == name.Replace(" ", "").ToLower());

        return entity ?? throw new NotFoundException(name, typeof(T).Name);
    }

    public async Task<bool> Delete<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id) ?? throw new NotFoundException(id.ToString(), typeof(T).Name);

        var property = typeof(T).GetProperty("ISDeleted");

        if (property != null && property.PropertyType == typeof(bool))
        {
            property.SetValue(entity, true);
            await _context.SaveChangesAsync();
        }

        return true;
    }

    #endregion
}
