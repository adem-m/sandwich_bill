namespace Domain.Exceptions;

public class UnknownIngredientException : Exception
{
    public UnknownIngredientException(string message) : base("Unknown ingredient: " + message)
    {
    }
}