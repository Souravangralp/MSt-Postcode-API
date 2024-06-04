namespace ProductMatrix.Application.Common.Interfaces;

public interface IGetDefaultSetting
{
    Task<dynamic> GetByProperty(string key);

    Task<string> GetByValue(string value);
}
