using System.ComponentModel.Design;
using Domain;

namespace Client;

public class Parser
{
    private Bill bill;
    public Menu menu;

    public Parser()
    {
        bill = new Bill();
        menu = new Menu();
    }
    public void AddSandwichList(string orderString)
    {
        string[] orderListString = orderString.Split(",");
        foreach (var order in orderListString)
        {
            AddSandwichFromString(order);
        }
    }
    public void AddSandwichFromString(string sandwichStringEntry)
    {
        // Parse string en Sandwich
        string[] quantitySandwichName = sandwichStringEntry.Split(" ");
        if (quantitySandwichName.Length != 2)
        {
            throw new InvalidEntryException(sandwichStringEntry);
        }
        string quantityString = quantitySandwichName[0].Trim();
        int quantity;
        try
        {
            quantity = int.Parse(quantityString);
        }
        catch (FormatException e)
        {
            throw new InvalidEntryException(sandwichStringEntry);
        }
        string sandwichString = quantitySandwichName[1].Trim();
        Sandwich sandwich = menu.getByName(sandwichString);
        bill.AddSandwich(sandwich);
    }
}