using Microsoft.EntityFrameworkCore;
using Moq;

namespace MSt_Postcode_API.Infrastructure.IntegrationTests;

public static class MockEntityExtension
{
    /// <summary>
    /// Creates a mock DbSet for a specified entity type with the provided list of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which the DbSet is created.</typeparam>
    /// <param name="entities">The list of entities to be included in the mock DbSet.</param>
    /// <returns>A mock DbSet containing the provided entities.</returns>
    public static Mock<DbSet<TEntity>> MockDbSet<TEntity>(List<TEntity> entities) where TEntity : class
    {
        var queryable = entities.AsQueryable();

        var mockDbSet = new Mock<DbSet<TEntity>>();
        mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

        return mockDbSet;
    }
}
