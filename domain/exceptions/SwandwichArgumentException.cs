using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public class SandwichArgumentException: ArgumentNullException
{
    public SandwichArgumentException(): base("Invalid sandwich: missing argument(s)")
    {
    }
}