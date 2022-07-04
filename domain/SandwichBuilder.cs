namespace Domain.Core;

public class SandwichBuilder
{
    private string Name;
    private Dictionary<Ingredient, Quantity> Ingredients;
    private Price Price;

    public SandwichBuilder()
    {
        Name = "";
        Ingredients = new Dictionary<Ingredient, Quantity>();
        Price = new(0, "");
    }

    public SandwichBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public SandwichBuilder WithIngredient(Ingredient ingredient, Quantity quantity)
    {
        Ingredients.Add(ingredient, quantity);
        return this;
    }

    public SandwichBuilder WithPrice(Price price)
    {
        Price = price;
        return this;
    }

    public Sandwich Build()
    {
        return new Sandwich(Name, Price, Ingredients);
    }
}