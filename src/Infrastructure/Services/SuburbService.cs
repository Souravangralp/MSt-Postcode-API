namespace ProductMatrix.Infrastructure.Services;

public class SuburbService : ISuburbService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly CancellationToken _cancellationToken = default;

    #endregion

    #region Ctor

    public SuburbService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Method

    public async Task GetSuburbDetails(List<PostcodeDetailDto> postcodeSourceData)
    {
        await SeedSuburbsAsync(postcodeSourceData);
        await SeedPostcodeSuburbMapperAsync(postcodeSourceData);
    }

    #region Helper Method

    private async Task SeedSuburbsAsync(List<PostcodeDetailDto> postcodeSourceData)
    {
        var states = await _context.States.ToListAsync();

        List<Suburb> suburbs = new List<Suburb>();

        foreach (var state in states)
        {
            var suburbsList = postcodeSourceData.Where(psd => psd.StateCode == state.AbbreivatedName);

            foreach (var suburb in suburbsList)
            {
                suburbs.Add(new Suburb { Suburb_SuburbStateID = state.ID, Name = suburb.Suburb });
            }
        }

        await _context.Suburbs.AddRangeAsync(suburbs);
        await _context.SaveChangesAsync(_cancellationToken);
    }

    private async Task SeedPostcodeSuburbMapperAsync(List<PostcodeDetailDto> postcodeSourceData)
    {
        var states = await _context.States.ToListAsync();

        List<PostcodeSuburbMapper> postcodeSuburbMapper = new List<PostcodeSuburbMapper>();

        int id = 0;

        foreach (var state in states)
        {
            var suburbsList = postcodeSourceData.Where(psd => psd.StateCode == state.AbbreivatedName);

            foreach (var suburb in suburbsList)
            {
                id++;

                postcodeSuburbMapper.Add(new PostcodeSuburbMapper
                {
                    PostcodeSuburbMapper_SuburbID = id,
                    PostcodeSuburbMapper_PostcodeID = suburb.Postcode + 1,
                    ISIsLand = suburb.ISIsLand
                });
            }
        }

        await _context.PostcodeSuburbMapper.AddRangeAsync(postcodeSuburbMapper);
        await _context.SaveChangesAsync(_cancellationToken);
    }

    #endregion

    #endregion
}
