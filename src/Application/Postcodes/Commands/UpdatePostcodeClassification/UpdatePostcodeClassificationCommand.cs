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
        List<int> classificationIds = [];

        await GetPostcodeClassificationIDs(request, classificationIds);

        var postcode = await GetPostcode(request.Postcode);

        return await UpdateClassifications(postcode.ID, classificationIds, cancellationToken);
    }

    #region Helpers

    private async Task<List<int>> GetPostcodeClassificationIDs(UpdatePostcodeClassificationCommand request, List<int> classificationIds)
    {
        var classifications = await _context.PostcodeClassifications.ToListAsync();

        if (classifications.Any())
        {
            GetProductClassification(request, classificationIds, classifications);
        }

        return classificationIds;
    }

    private static void GetProductClassification(UpdatePostcodeClassificationCommand request, List<int> classificationIds, List<PostcodeClassification> classifications)
    {
        foreach (var classification in classifications)
        {
            if (request.HighSecurity is not null && request.HighSecurity.Any())
            {
                foreach (var highSecurity in request.HighSecurity)
                {
                    if (classification.Value.Replace(" ", "").ToLower() == highSecurity.Replace(" ", "").ToLower())
                    {
                        classificationIds.Add(classification.ID);
                    }
                }
            }

            if (classification.Value.Replace(" ", "").ToLower() == request.PCCategory.Replace(" ", "").ToLower() ||
                       classification.Value.Replace(" ", "").ToLower() == request.StandardAndPoor.Replace(" ", "").ToLower())
            {
                classificationIds.Add(classification.ID);
            }
        }
    }

    private async Task<Postcode> GetPostcode(string postcode)
    {
        return await _context.Postcodes.Where(code => code.Code.Replace(" ", "").ToLower() == postcode.Replace(" ", "").ToLower())
                .FirstOrDefaultAsync() ?? throw new NotFoundException(postcode, nameof(postcode));
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
