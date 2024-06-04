namespace ProductMatrix.Domain.Constants;

public record CrudOperation(string Operation)
{
    public static readonly CrudOperation Create = new ("Create");

    public static readonly CrudOperation GetAll = new ("GetAll");

    public static readonly CrudOperation Update = new ("Update");

    public static readonly CrudOperation Delete = new ("Delete");
}
