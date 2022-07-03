namespace Domain.Exceptions;

using System;
using Domain.Core;

public class SandwichNotInBillException : Exception
{
    public SandwichNotInBillException(Sandwich sandwich) : base($"Le sandwich {sandwich.Name} n'existe pas")
    {
    }
}