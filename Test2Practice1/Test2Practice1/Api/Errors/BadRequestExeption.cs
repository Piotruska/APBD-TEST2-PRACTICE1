namespace Test2Practice1.Api.Errors;

public class BadRequestExeption : Exception
{
    public BadRequestExeption(string? message) : base(message)
    {
    }
}