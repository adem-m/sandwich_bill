using Domain.Exceptions;

namespace Domain.Core;

public class SandwichBuilder
{
    private string? _name;
    private Dictionary<Ingredient, Quantity> _ingredients = new Dictionary<Ingredient, Quantity>();
    private Price? _price;
    private static readonly DataStore _dataStore = DataStore.Instance;

    public SandwichBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SandwichBuilder WithIngredient(Ingredient ingredient, Quantity quantity)
    {
        _ingredients.Add(ingredient, quantity);
        return this;
    }

    public SandwichBuilder WithPrice(Price price)
    {
        _price = price;
        return this;
    }

    public Sandwich Build()
    {
        if (_name is null || _ingredients.Count == 0 || _price is null)
        {
            throw new SandwichArgumentException();
        } 
        _price = DataStore.GetPrice(_ingredients);

        if (_name is null)
        {
            return new Sandwich(_price.Value, _ingredients);
        }
   
        return new Sandwich(_name, _price.Value, _ingredients);
    }
}