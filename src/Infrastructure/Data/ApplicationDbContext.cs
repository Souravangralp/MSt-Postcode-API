namespace MSt_Postcode_API.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Postcode> Postcodes => Set<Postcode>();

    public DbSet<State> States => Set<State>();

    public DbSet<Suburb> Suburbs => Set<Suburb>();

    public DbSet<PostcodeClassification> PostcodeClassifications => Set<PostcodeClassification>();

    public DbSet<PostcodeSpecificationMapper> PostcodeSpecificationMapper => Set<PostcodeSpecificationMapper>();

    public DbSet<PostcodeSuburbMapper> PostcodeSuburbMapper => Set<PostcodeSuburbMapper>();

    public DbSet<PostcodeClassificationMapper> PostcodeClassificationMapper => Set<PostcodeClassificationMapper>();

    public DbSet<GeneralLookup> GeneralLookups => Set<GeneralLookup>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
