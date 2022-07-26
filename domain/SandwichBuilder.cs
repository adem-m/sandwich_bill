using System.Linq;
using Domain.Exceptions;

namespace Domain.Core;

public class SandwichBuilder
{
    private static string DEFAULT_CURRENCY = "EUR";
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
        if (_name is null || _ingredients.Count == 0)
        {
            throw new SandwichArgumentException();
        } 

        if (_price is null)
        {
            _price = DataStore.GetPrice(_ingredients);
        }
   
        return new Sandwich(_name, _price.Value, _ingredients);
    }
}