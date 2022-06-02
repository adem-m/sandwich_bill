using System.Collections.Generic;
using Domain;

namespace DefaultNamespace;

public class Order
{
    public List<Sandwich> Sandwiches { get; } = new();

    public Order(List<Sandwich> sandwiches)
    {
        Sandwiches = sandwiches;
    }

    public void AddSandwich(Sandwich sandwich)
    {
        Sandwiches.Add(sandwich);
    }
}