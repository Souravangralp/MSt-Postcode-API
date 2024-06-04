namespace ProductMatrix.Application.Common.Interfaces;

public interface ICalculateRangeService
{
    Task<int?> GetLVR(double value);

    //Task<int?> GetDwelling(int value);
}
