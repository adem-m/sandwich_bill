namespace Domain.Core;

using Domain.Exceptions;
public class Quantity
{
    public decimal Value { get; private set; }
    public string? Unit { get; private set; }

    public Quantity(decimal value)
    {
        Value = value;
    }

    public Quantity(decimal Value, string? unit) : this(Value)
    {
        Unit = unit;
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Quantity quantity = ((Quantity)obj);
        return Value == quantity.Value && Unit == quantity.Unit;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
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