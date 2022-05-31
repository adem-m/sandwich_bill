namespace Domain;
public class Sandwich
{
    public string Name { get; private set; }
    private Dictionary<Ingredient,Quantity> Ingredients;

    public Price Price { get; private set; }

    public Sandwich(string name, Price price)
    {
        Name = name;
        Ingredients = new Dictionary<Ingredient, Quantity>();
        Price = price;
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {       
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        var sandwich = (Sandwich) obj;
        return Name == sandwich.Name && 
            Ingredients.GetHashCode() == sandwich.Ingredients.GetHashCode() &&
            Price == sandwich.Price;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    
    // Add an ingredient to the sandwich
    public void AddIngredient(Ingredient ingredient, Quantity quantity)
    {
        var defaultQuantity = Ingredients.GetValueOrDefault(
            ingredient, 
            new Quantity(new Decimal(0.0), quantity.Unit)
        );
        Ingredients.Add(ingredient, defaultQuantity + quantity);
    }

    public override string ToString() {
        return Ingredients.Aggregate(
            "", 
            (acc, entry) =>  acc + $"\t{entry.Value} {entry.Key} \n"
        );
    }
}
