using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.Postcodes.Queries.GetPostcodeResult;

public record GetPostcodeResult : IRequest<PostcodeResult>
{
    public required string Postcode { get; set; }

    public required string StateORTerritoryName { get; set; }
}

public class GetPostcodeResultHandler(IApplicationDbContext context) : IRequestHandler<GetPostcodeResult, PostcodeResult>
{
    #region Fields

    private readonly IApplicationDbContext _context = context;

    #endregion

    #region Methods

    public async Task<PostcodeResult> Handle(GetPostcodeResult request, CancellationToken cancellationToken)
    {
        List<PostcodeClassification> postcodeClassifications = [];

        var state = await _context.States.Where(state => state.Name.Replace(" ", "").ToLower() == request.StateORTerritoryName.Replace(" ", "").ToLower())
                                         .AsNoTracking()
                                        .FirstOrDefaultAsync(cancellationToken);

        var postcode = await _context.Postcodes.Where(postcode => postcode.Postcode_StateID == (state == null ? null : state.ID) || postcode.Code.Replace(" ", "").ToLower() == request.Postcode.Replace(" ", "").ToLower())
                                               .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.Postcode, nameof(Postcode));


        var postcodeClassificationIds = await _context.PostcodeClassificationMapper.Where(pcm => pcm.PostcodeClassificationMapper_PostcodeID == postcode.ID && pcm.PostcodeClassificationMapper_PostcodeClassificationID != null)
                                                                                      .Select(pcm => pcm.PostcodeClassificationMapper_PostcodeClassificationID)
                                                                                      .ToListAsync(cancellationToken);

        foreach (var pcId in postcodeClassificationIds)
        {
            if (pcId.HasValue)
            {
                var postcodeClassification = await _context.PostcodeClassifications.Where(pc => pc.ID == pcId.Value).FirstOrDefaultAsync(cancellationToken);

                if (postcodeClassification is not null) { postcodeClassifications.Add(postcodeClassification); }
            }
        }

        return GetPostcodeResult(postcodeClassifications);
    }

    #region Helpers

    private static PostcodeResult GetPostcodeResult(List<PostcodeClassification> postcodeClassifications)
    {
        PostcodeResult postcodeResult = new()
        {
            Capital = "Excluded",
            PcCategory = "Unlisted"
        };

        foreach (var pc in postcodeClassifications)
        {
            if (pc.Name.Replace(" ", "").ToLower() == PostcodeClassificationType.StandardAndPoor.Value.Replace(" ", "").ToLower())
            {
                postcodeResult.PcCategory = pc.Value;
            }
            if (pc.Name.Replace(" ", "").ToLower() == PostcodeClassificationType.PCCategory.Value.Replace(" ", "").ToLower())
            {
                postcodeResult.Capital = pc.Value;
            }
            if (pc.Name.Replace(" ", "").ToLower() == PostcodeClassificationType.HighSecurity.Value.Replace(" ", "").ToLower())
            {
                if (pc.Value.Replace(" ", "").ToLower() == HighSecurityType.HighDensity.Value.Replace(" ", "").ToLower())
                {
                    postcodeResult.ISHighDensity = true;
                }
                if (pc.Value.Replace(" ", "").ToLower() == HighSecurityType.SelectedNonMetro.Value.Replace(" ", "").ToLower())
                {
                    postcodeResult.ISSelectedNonMetro = true;
                }
                if (pc.Value.Replace(" ", "").ToLower() == HighSecurityType.MetroPlus.Value.Replace(" ", "").ToLower())
                {
                    postcodeResult.ISMetroPlus = true;
                }
            }
        }

        return postcodeResult;
    }

    #region Working based on Rashid calculator

    //public async Task<PostcodeResult> Handle(GetPostcodeResult request, CancellationToken cancellationToken)
    //{
    //    if (request.Postcode <= (int)PostcodeTypes.Excluded)
    //    {
    //        return await GetExcludedPostResult(request, cancellationToken);
    //    }

    //    var state = await _context.States.Where(state => state.Name.Replace(" ", "").ToLower() == request.StateORTerritoryName.Replace(" ", "").ToLower() ||
    //                state.AbbreivatedName.Replace(" ", "").ToLower() == request.StateORTerritoryName.Replace(" ", "").ToLower())
    //        .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.StateORTerritoryName, nameof(State));

    //    var standardAndPoorPostcode = await _context.StandardAndPoorPostcodes.Where(sapp => sapp.From <= request.Postcode &&
    //                sapp.To >= request.Postcode && sapp.StandardAndPoorPostcode_StateID == state.ID)
    //        .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.Postcode.ToString(), nameof(StandardAndPoorPostcode));

    //    return await GetPostcodeResult(state.ID, request, standardAndPoorPostcode);
    //}


    #region Helpers

    //private async Task<PostcodeResult> GetExcludedPostResult(GetPostcodeResult request, CancellationToken cancellationToken)
    //{
    //    var state2 = await _context.StandardAndPoorPostcodes.Where(sapp => sapp.From < request.Postcode && sapp.To >= request.Postcode)
    //                        .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.StateORTerritoryName, nameof(StandardAndPoorPostcode));

    //    var postcodeDetails = await _context.Postcodes.Where(postcode => Convert.ToInt32(postcode.Code) <= (int)PostcodeTypes.Excluded)
    //        .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.StateORTerritoryName, nameof(State));

    //    return new PostcodeResult()
    //    {
    //        Capital = "Unlisted",
    //        ISHighDensity = postcodeDetails.ISHighDensity,
    //        ISMetroPlus = postcodeDetails.ISMetroPlus,
    //        ISSelectedNonMetro = postcodeDetails.ISSelectedNonMetro,
    //        PcCategory = state2.Location
    //    };
    //}

    //private async Task<PostcodeResult> GetPostcodeResult(int stateId, GetPostcodeResult request, StandardAndPoorPostcode standardAndPoorPostcode)
    //{
    //    var postcode = await _context.Postcodes.Where(pc => pc.Code == request.Postcode.ToString() && pc.Postcode_StateID == stateId)
    //        .FirstOrDefaultAsync() ?? throw new NotFoundException(request.Postcode.ToString(), nameof(Postcode));

    //    var category = await _context.CategoryTypes.Where(pc => pc.ID == postcode.Postcode_CategoryTypeID).FirstOrDefaultAsync();

    //    return new()
    //    {
    //        ISMetroPlus = postcode.ISMetroPlus,
    //        ISSelectedNonMetro = postcode.ISSelectedNonMetro,
    //        ISHighDensity = postcode.ISHighDensity,
    //        Capital = category?.Name ?? "",
    //        PcCategory = standardAndPoorPostcode.Location
    //    };
    //}

    #endregion

    #endregion

    #endregion

    #endregion
}
