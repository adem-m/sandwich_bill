namespace Domain;

public class Bill {
    public Dictionary<Sandwich, int> sandwiches { get; private set; }

    public Bill() {
        sandwiches = new Dictionary<Sandwich, int>();
    }

    public void AddSandwich(Sandwich sandwich) {
        if(sandwiches.ContainsKey(sandwich)) {
            sandwiches[sandwich]++;
        } else {
            sandwiches.Add(sandwich, 1);
        }
    }

    public void RemoveSandwich(Sandwich sandwich) {
        if(!sandwiches.ContainsKey(sandwich)) {
            throw new SandwichNotInBillException(sandwich);
        }
        sandwiches[sandwich]--;
    }

    public Price Total => 
        sandwiches.Aggregate(
            new Price(0, "€"), 
            (acc, entry) => entry.Key.Price * entry.Value + acc
        );
    
    public override string ToString() 
    {
        String result = sandwiches.Aggregate(
            "", 
            (acc, entry) => $"{entry.Value} {entry.Key.Name}: \n {entry.Key.ToString} \n"
        );
        return result + $"Prix total: {Total}";
    }
}