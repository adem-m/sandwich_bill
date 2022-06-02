namespace Domain;

public class Price
{
    public decimal Value { get; }
    public string Currency { get; }

    public Price(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Price price = ((Price)obj);
        return Value == price.Value && Currency == price.Currency;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
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