namespace ProductMatrix.Application.Common.Interfaces;

public interface IPostcodeService
{
    Task<List<PostcodeClassificationMapper>> GetPostcodeClassificationMapper();
}
