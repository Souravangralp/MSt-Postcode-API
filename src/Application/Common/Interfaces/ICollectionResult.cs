namespace ProductMatrix.Application.Common.Interfaces;

public interface ICollectionResult
{
    string FilterName { get; }

    List<object> Collection { get; }
}
