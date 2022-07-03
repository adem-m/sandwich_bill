namespace Domain.Core;

using Domain.Exceptions;
public readonly struct Quantity
{
    public decimal Value { get; init; }
    public string? Unit { get; init; }

    public Quantity(decimal value)
    {
        Value = value;
        Unit = null;
    }

    public Quantity(decimal value, string? unit)
    {
        Value = value;
        Unit = unit;
    }

    public static Quantity operator +(Quantity quantity1, Quantity quantity2)
    {
        if (quantity1.Unit != quantity2.Unit)
        {
            throw new InvalidQuantityOperation();
        }

        return new Quantity(quantity1.Value + quantity2.Value, quantity1.Unit);
    }

    public override string ToString() => $"{Value}{Unit}";
}