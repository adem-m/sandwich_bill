using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain.Core;

public class DataStore : Menu
{
    private static DataStore? _instance;
    private static object _lock = new object();

    public static DataStore Instance
    {
        get
        {
            if (_instance == null)
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DataStore();
                        _instance.AddEntry(HAM_BUTTER);
                        _instance.AddEntry(CHICKEN_VEGETABLES);
                        _instance.AddEntry(DIEPPOIS);
                    }
                }
            }
            return _instance;
        } 
    }

    private static string DEFAULT_CURRENCY = "EUR";
    private static string GRAMS_UNIT = "g";

    private static Ingredient BREAD = new("Pain");
    private static Ingredient HAM = new("Tranche de jambon");
    private static Ingredient BUTTER = new("Beurre");
    private static Ingredient EGG = new("Oeuf");
    private static Ingredient TOMATO = new("Tomate");
    private static Ingredient CHICKEN = new("Tranche de poulet");
    private static Ingredient MAYONNAISE = new("Mayonnaise");
    private static Ingredient SALAD = new("Salade");
    private static Ingredient TUNA = new("Thon");

    private static Dictionary<string, Ingredient> _ingredients = new();

    private static Sandwich HAM_BUTTER = new SandwichBuilder()
        .WithName("Jambon beurre")
        .WithPrice(new Price(3.5m, DEFAULT_CURRENCY))
        .WithIngredient(BREAD, new Quantity(1))
        .WithIngredient(HAM, new Quantity(1))
        .WithIngredient(BUTTER, new Quantity(10, GRAMS_UNIT))
        .Build();

    private static Sandwich CHICKEN_VEGETABLES = new SandwichBuilder()
        .WithName("Poulet crudités")
        .WithPrice(new Price(5, DEFAULT_CURRENCY))
        .WithIngredient(BREAD, new Quantity(1))
        .WithIngredient(EGG, new Quantity(1))
        .WithIngredient(TOMATO, new Quantity(0.5m))
        .WithIngredient(CHICKEN, new Quantity(1))
        .WithIngredient(MAYONNAISE, new Quantity(10, GRAMS_UNIT))
        .WithIngredient(SALAD, new Quantity(10, GRAMS_UNIT))
        .Build();

    private static Sandwich DIEPPOIS = new SandwichBuilder()
        .WithName("Dieppois")
        .WithPrice(new Price(4.5m, DEFAULT_CURRENCY))
        .WithIngredient(BREAD, new Quantity(1))
        .WithIngredient(TUNA, new Quantity(50, GRAMS_UNIT))
        .WithIngredient(TOMATO, new Quantity(0.5m))
        .WithIngredient(MAYONNAISE, new Quantity(10, GRAMS_UNIT))
        .WithIngredient(SALAD, new Quantity(10, GRAMS_UNIT))
        .Build();

    private Dictionary<string, Sandwich> _data = new();

    private DataStore()
    {
        _ingredients.Add(BREAD.Name, BREAD);
        _ingredients.Add(HAM.Name, HAM);
        _ingredients.Add(BUTTER.Name, BUTTER);
        _ingredients.Add(EGG.Name, EGG);
        _ingredients.Add(TOMATO.Name, TOMATO);
        _ingredients.Add(CHICKEN.Name, CHICKEN);
        _ingredients.Add(MAYONNAISE.Name, MAYONNAISE);
        _ingredients.Add(SALAD.Name, SALAD);
        _ingredients.Add(TUNA.Name, TUNA);
    }

    public void AddEntry(Sandwich sandwich)
    {
        _data.Add(sandwich.Name, sandwich);
    }

    public Sandwich getByName(string name)
    {
        if (!_data.ContainsKey(name))
        {
            throw new UnknownSandwichException(name);
        }
        return _data[name];
    }

    public Sandwich createSandwich(string sandwich)
    {
        if (_data.ContainsKey(sandwich))
            return _data[sandwich];

        Dictionary<Ingredient, Quantity> ingredients = new Dictionary<Ingredient, Quantity>();

        List<string> ingredientList = sandwich.Split(" ").ToList();
        ingredientList.ForEach(ingredientEntry =>
        {
            string[] ingredientNameAndQuantity = ingredientEntry.Split(":");
            if (ingredientNameAndQuantity.Length != 2)
                throw new InvalidIngredientFormat(ingredientEntry);

            string ingredientName = ingredientNameAndQuantity[0];
            string ingredientQuantity = ingredientNameAndQuantity[1];
            if (ingredientNameAndQuantity.Length != 2)
                throw new InvalidIngredientFormat(ingredientEntry);

            Ingredient ingredient = MapIngredient(ingredientName);
            Quantity quantity = MapQuantity(ingredientQuantity);

            ingredients.Add(ingredient, quantity);
        });
        Price price = new Price(ingredients.Count, DEFAULT_CURRENCY);
        SandwichBuilder builder = new SandwichBuilder()
            .WithName("Sandwich custom")
            .WithPrice(price);

        foreach (KeyValuePair<Ingredient, Quantity> entry in ingredients)
            builder.WithIngredient(entry.Key, entry.Value);

        return builder.Build();
    }

    private Ingredient MapIngredient(string entry)
    {
        Ingredient? ingredient = _ingredients.GetValueOrDefault(entry);
        if (!ingredient.HasValue)
            throw new UnknownIngredientException(entry);

        return ingredient.Value;
    }

    private Quantity MapQuantity(string ingredientQuantity)
    {
        string[] ingredientQuantityWithUnit = ingredientQuantity.Split("_");
        if (ingredientQuantityWithUnit.Length > 2)
            throw new InvalidQuantityFormat(ingredientQuantity);

        decimal quantityEntry = decimal.Parse(ingredientQuantityWithUnit[0]);
        string? unit = ingredientQuantityWithUnit.Length == 2 ? ingredientQuantityWithUnit[1] : null;

        return unit == null ? new Quantity(quantityEntry) : new Quantity(quantityEntry, unit);
    }
}