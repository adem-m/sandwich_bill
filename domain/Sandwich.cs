using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Core;

public struct Sandwich
{
    public string Name { get; init; }
    private Dictionary<Ingredient, Quantity> Ingredients;

    public Price Price { get; init; }

    public Sandwich(string name, Price price)
    {
        Name = name;
        Ingredients = new Dictionary<Ingredient, Quantity>();
        Price = price;
    }

    public Sandwich(string name, Price price, Dictionary<Ingredient, Quantity> ingredients)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
    }

    // Add an ingredient to the sandwich
    public void AddIngredient(Ingredient ingredient, Quantity quantity)
    {
        if (Ingredients.ContainsKey(ingredient))
        {
            Ingredients[ingredient] += quantity;
            return;
        }

        Ingredients.Add(ingredient, quantity);
    }

    public override string ToString()
    {
        return Ingredients.Aggregate(
            "",
            (acc, entry) => acc + $"\t{entry.Value} {entry.Key} \n"
        );
    }
}