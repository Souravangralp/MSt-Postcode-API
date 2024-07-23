namespace MSt_Postcode_API.Application.Postcodes.Commands.UpdatePostcodeClassification;

public class UpdatePostcodeClassificationCommand : IRequest<bool>
{
    public required string Postcode { get; set; }

    public required string PCCategory { get; set; }

    public required string StandardAndPoor { get; set; }

    public List<string>? HighSecurity { get; set; }
}

public class UpdatePostcodeClassificationCommandHandler : IRequestHandler<UpdatePostcodeClassificationCommand, bool>
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public UpdatePostcodeClassificationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<bool> Handle(UpdatePostcodeClassificationCommand request, CancellationToken cancellationToken)
    {
        var postcode = await _context.Postcodes.Where(code => code.Code.Trim().ToLower() == request.Postcode.Trim().ToLower())
                .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(request.Postcode, nameof(Postcode));

        List<int> classificationIds = await GetPostcodeClassificationIDs(request);

        return await UpdateClassifications(postcode.ID, classificationIds, cancellationToken);
    }

    #region Helpers

    private async Task<List<int>> GetPostcodeClassificationIDs(UpdatePostcodeClassificationCommand request)
    {
        var classifications = await _context.PostcodeClassifications.ToListAsync();

        return classifications.Any() 
            ? PostcodeUtility.GetClassification(request, classifications) 
            : [];
    }

    private async Task<bool> UpdateClassifications(int postcodeID, List<int> classificationIds, CancellationToken cancellationToken)
    {
        List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

        var toBeDeletedPostcodeClassificationMapper = await _context.PostcodeClassificationMapper.Where(pcm => pcm.PostcodeClassificationMapper_PostcodeID == postcodeID &&
                                                                                                               !pcm.ISDeleted)
                                                                                                 .ToListAsync();
        toBeDeletedPostcodeClassificationMapper.ForEach(pcm => pcm.ISDeleted = true);

        foreach (var classificationId in classificationIds)
        {
            postcodeClassificationMapper.Add(new()
            {
                PostcodeClassificationMapper_PostcodeID = postcodeID,
                PostcodeClassificationMapper_PostcodeClassificationID = classificationId
            });
        }

        _context.PostcodeClassificationMapper.AddRange(postcodeClassificationMapper);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    #endregion
}
