namespace Domain.Exceptions;

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException(String quantity) : base($"{quantity} n'est pas une quantité valide")
    {
    }
}