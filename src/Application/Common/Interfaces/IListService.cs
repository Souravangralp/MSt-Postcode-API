namespace ProductMatrix.Application.Common.Interfaces;

public interface IListService
{
    Task<TextValuePair[]> GetAll<T>() where T : class;
}
