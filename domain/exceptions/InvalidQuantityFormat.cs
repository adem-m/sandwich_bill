namespace Domain.Exceptions;

public class InvalidQuantityFormat : Exception
{
    public InvalidQuantityFormat(string message) : base("Invalid quantity format: " + message)
    {
    }
}