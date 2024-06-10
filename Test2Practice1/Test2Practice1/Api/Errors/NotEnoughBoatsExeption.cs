namespace Test2Practice1.Api.Errors;

public class NotEnoughBoatsExeption : Exception
{
    public NotEnoughBoatsExeption(string? message) : base(message)
    {
    }
}