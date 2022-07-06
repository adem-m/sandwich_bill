namespace Domain.Exceptions;

public class InvalidIngredientFormat : Exception
{
    public InvalidIngredientFormat(string message) : base("Invalid ingredient format: " + message + 
                                                          "\nValid format: <name>:<amount>(_<unit>)")
    {
    }
}