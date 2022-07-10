using Domain.Core;

namespace Domain.Exceptions;

public class UnknownIngredientException : Exception
{
    public UnknownIngredientException(Ingredient ingredient) : base($"T'as cru qu'on avait du ou de la {ingredient.Name} ??")
    {
    }
}