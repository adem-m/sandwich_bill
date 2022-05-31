namespace Domain;
using System;

public class SandwichNotInBillException : Exception
{

    public SandwichNotInBillException(Sandwich sandwich) : base(string.Format("The sandwich {0} is not in the bill", sandwich.Name)){}

}