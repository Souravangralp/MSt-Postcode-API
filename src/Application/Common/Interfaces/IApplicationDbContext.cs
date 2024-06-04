using MSt_Postcode_API.Domain.Entities;
using MSt_Postcode_API.Domain.Entities.Generals;
using MSt_Postcode_API.Domain.Entities.Mappers;

namespace MSt_Postcode_API.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Postcode> Postcodes { get; }

    DbSet<State> States { get; }

    DbSet<Suburb> Suburbs { get; }

    DbSet<PostcodeClassification> PostcodeClassifications { get; }

    DbSet<PostcodeSuburbMapper> PostcodeSuburbMapper { get; }

    DbSet<PostcodeSpecificationMapper> PostcodeSpecificationMapper { get; }

    DbSet<PostcodeClassificationMapper> PostcodeClassificationMapper { get; }

    DbSet<GeneralLookup> GeneralLookups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
