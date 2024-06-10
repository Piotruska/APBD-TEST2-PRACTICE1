namespace Test2Practice1.Api.Errors;

public class NotFoundExeption : Exception
{
    public NotFoundExeption(string? message) : base(message)
    {
    }
}