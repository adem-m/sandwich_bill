using System.Collections.Generic;
using Domain;

namespace DefaultNamespace;

public class DataStore
{
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

    private static Sandwich HAM_BUTTER = new(
        "Jambon beurre",
        new Price(3.5m, DEFAULT_CURRENCY),
        new Dictionary<Ingredient, Quantity>
        {
            { BREAD, new Quantity(1) },
            { HAM, new Quantity(1) },
            { BUTTER, new Quantity(10, GRAMS_UNIT) }
        }
    );

    private static Sandwich CHICKEN_VEGETABLES = new(
        "Poulet crudités",
        new Price(5, DEFAULT_CURRENCY),
        new Dictionary<Ingredient, Quantity>
        {
            { BREAD, new Quantity(1) },
            { EGG, new Quantity(1) },
            { TOMATO, new Quantity(0.5m) },
            { CHICKEN, new Quantity(1) },
            { MAYONNAISE, new Quantity(10, GRAMS_UNIT) },
            { SALAD, new Quantity(10, GRAMS_UNIT) }
        }
    );

    private static Sandwich DIEPPOIS = new(
        "Dieppois",
        new Price(4.5m, DEFAULT_CURRENCY),
        new Dictionary<Ingredient, Quantity>
        {
            { BREAD, new Quantity(1) },
            { TUNA, new Quantity(50, GRAMS_UNIT) },
            { TOMATO, new Quantity(0.5m) },
            { MAYONNAISE, new Quantity(10, GRAMS_UNIT) },
            { SALAD, new Quantity(10, GRAMS_UNIT) }
        }
    );

    public Menu Menu { get; } = new();

    public DataStore()
    {
        Menu.AddEntry(HAM_BUTTER);
        Menu.AddEntry(CHICKEN_VEGETABLES);
        Menu.AddEntry(DIEPPOIS);
    }
}