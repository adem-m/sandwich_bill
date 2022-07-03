using System;

namespace Domain.Exceptions;

public class UnknownSandwichException : Exception
{
    public UnknownSandwichException(string sandwichName) : base("Sandwich inconnu : " + sandwichName)
    {
    }
}