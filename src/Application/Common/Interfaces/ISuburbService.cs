namespace ProductMatrix.Application.Common.Interfaces;

public interface ISuburbService
{
    Task GetSuburbDetails(List<PostcodeDetailDto> postcodeSourceData);
}
