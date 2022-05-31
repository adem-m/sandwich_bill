namespace Domain;

using System.Collections.Generic;

public class Menu
{
    private Dictionary<string, Sandwich> _data = new Dictionary<string, Sandwich>();

    public void AddEntry(Sandwich sandwich)
    {
        _data.Add(sandwich.Name, sandwich);
    }

    public Sandwich getByName(string name) => _data[name];
}