namespace Domain.Core;

using Domain.Exceptions;

public readonly struct Price
{
    public decimal Value { get; init; }
    public string Currency { get; init; }

    public Price(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public override string ToString()
    {
        return $"{Currency} {Value}";
    }

    public static Price operator +(Price price1, Price price2)
    {
        if (price1.Currency != price2.Currency)
        {
            throw new InvalidPriceOperation();
        }

        return new Price(price1.Value + price2.Value, price1.Currency);
    }

    public static Price operator *(Price price, int factor) =>
        new Price(price.Value * factor, price.Currency);

    public static Price operator *(int factor, Price price) =>
        new Price(price.Value * factor, price.Currency);
}