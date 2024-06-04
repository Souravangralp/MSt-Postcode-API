namespace ProductMatrix.Application.Common.Interfaces;

public interface IEntityService
{
    Task<T> Get<T>(int id) where T : class;

    Task<T> GetByName<T>(string name) where T : class;

    Task<bool> Delete<T>(int id) where T : class;
}
