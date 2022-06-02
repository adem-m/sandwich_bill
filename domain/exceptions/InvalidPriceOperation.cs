namespace Domain;

using System;

public class InvalidPriceOperation : InvalidOperationException
{
    public InvalidPriceOperation() : base("Attempting an invalid operation on prices.")
    {
    }
}