namespace ProductMatrix.Application.Common.Interfaces;

public interface IGeneralLookUpService
{
    Task<int> GetGeneralLookUpID(string type, string value);

    Task<GeneralLookUp> Create(string type, string value);
}
