namespace Domain.Exceptions;

using System;

public class InvalidQuantityOperation : InvalidOperationException
{
    public InvalidQuantityOperation() : base("Attempting an invalid operation with quantities.")
    {
    }
}