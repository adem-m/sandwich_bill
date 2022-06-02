namespace Domain;

using System;

public class SandwichNotInBillException : Exception
{
    public SandwichNotInBillException(Sandwich sandwich) : base($"Le sandwich {sandwich.Name} n'existe pas")
    {
    }
}