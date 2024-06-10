namespace Test2Practice1.Api.Errors;

public class UnauthorizedExeption : Exception
{
    public UnauthorizedExeption(string? message) : base(message)
    {
    }
}