using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Core;

public class Sandwich
{
    public string Name { get; init; }
    private Dictionary<Ingredient, Quantity> _ingredients;
    public ReadOnlyCollection<(Ingredient, Quantity)> Ingredients
    {
        get => 
            _ingredients
                .Select(pair => (pair.Key, pair.Value))
                .ToList()
                .AsReadOnly();
    }

    public Price Price { get; set; }


    public Sandwich(string name, Price price, Dictionary<Ingredient, Quantity> ingredients)
    {
        Name = name;
        _ingredients = ingredients;
        Price = price;
    }

    public Sandwich(Price price, Dictionary<Ingredient, Quantity> ingredients): 
        this("Sandwich custom", price, ingredients)
    {
    }

    // Add an ingredient to the sandwich
    public void AddIngredient(Ingredient ingredient, Quantity quantity)
    {
        if (_ingredients.ContainsKey(ingredient))
        {
            _ingredients[ingredient] += quantity;
            return;
        }

        _ingredients.Add(ingredient, quantity);
    }

    public override string ToString()
    {
        return _ingredients.Aggregate(
            "",
            (acc, entry) => acc + $"\t{entry.Value} {entry.Key} \n"
        );
    }
}