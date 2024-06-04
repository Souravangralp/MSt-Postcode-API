﻿using MSt_Postcode_API.Domain.Entities.Mappers;

namespace MSt_Postcode_API.Application.Common.Interfaces;

public interface ISeedPostcodeClassificationService
{
    Task<List<PostcodeClassificationMapper>> GetAll(string fileName, string sheetName);
}
