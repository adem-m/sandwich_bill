using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Core;

public class Order
{
    private List<Sandwich> _sandwiches;
    public ReadOnlyCollection<Sandwich> Sandwiches
    {
        get => _sandwiches.AsReadOnly();
    }

    public Order(List<Sandwich> sandwiches)
    {
        _sandwiches = sandwiches;
    }

    public void AddSandwich(Sandwich sandwich)
    {
        _sandwiches.Add(sandwich);
    }
}