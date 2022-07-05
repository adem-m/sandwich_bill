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
}