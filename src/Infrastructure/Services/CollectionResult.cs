namespace ProductMatrix.Infrastructure.Services;

public class CollectionResult<T> : ICollectionResult where T : class
{
    public string FilterName { get; set; } = string.Empty;

    List<object> ICollectionResult.Collection => Collection.Cast<object>().ToList();

    public List<T> Collection { get; set; } = new List<T>();
}
