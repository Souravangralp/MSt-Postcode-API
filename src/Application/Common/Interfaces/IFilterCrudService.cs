namespace ProductMatrix.Application.Common.Interfaces;

public interface IFilterCrudService
{
    Task<dynamic> PerformCrud(object request, string operationName);
}
