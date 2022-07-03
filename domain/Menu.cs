using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain.Core;

public interface Menu
{
    void AddEntry(Sandwich sandwich);
    Sandwich getByName(string name);
    // private Dictionary<string, Sandwich> _data = new();

    // public void AddEntry(Sandwich sandwich)
    // {
    //     _data.Add(sandwich.Name, sandwich);
    // }

    // public Sandwich getByName(string name)
    // {
    //     if (!_data.ContainsKey(name))
    //     {
    //         throw new UnknownSandwichException(name);
    //     }

    //     return _data[name];
    // }
}