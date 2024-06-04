using MSt_Postcode_API.Domain.Entities;
using MSt_Postcode_API.Domain.Entities.Mappers;

namespace MSt_Postcode_API.Application.Common.Interfaces;

public interface ISeedPostcodeSuburbService
{
    Task<List<Suburb>> GetSuburbs(string fileName, string SheetName);

    Task<List<PostcodeSuburbMapper>> GetPostcodeSuburbMapper(string fileName, string sheetName);

    Task<List<Postcode>> GetPostcodes();
}
