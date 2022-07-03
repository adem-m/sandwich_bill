using System;

namespace Domain.Exceptions;

public class InvalidPriceOperation : InvalidOperationException
{
    public InvalidPriceOperation() : base("Attempting an invalid operation on prices.")
    {
    }
}