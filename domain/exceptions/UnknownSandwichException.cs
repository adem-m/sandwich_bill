using System;

namespace Client;

public class UnknownSandwichException : Exception
{
    public UnknownSandwichException(string sandwichName) : base("Sandwich inconnu : " + sandwichName)
    {
    }
}