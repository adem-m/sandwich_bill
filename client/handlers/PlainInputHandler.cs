using Client.Exceptions;

namespace Domain.Core.handlers;

public class PlainInputHandler : InputHandler
{
    private DataStore DataStore { get; set; }

    private PlainInput _input { get; set; }
    
    public PlainInputHandler( PlainInput input)
    {
        DataStore = DataStore.Instance;
        _input = input;
    }
    
    public Order handle()
    {
        return new Order(parseLine(_input.Content));
    }
    
    private List<Sandwich> parseLine(String line)
    {
        List<string> orderListString = line.Split(",").ToList();
        List<Sandwich> result = new List<Sandwich>();
        orderListString.ForEach(entry =>
        {
            string trimmedEntry = entry.Trim();
            int spaceIndex = trimmedEntry.IndexOf(" ", StringComparison.Ordinal);
            if (spaceIndex == -1) throw new InvalidEntryException(trimmedEntry);

            string stringQuantity = trimmedEntry.Substring(0, spaceIndex);

            int sandwichQuantity;
            try
            {
                sandwichQuantity = int.Parse(stringQuantity);
            }
            catch (FormatException)
            {
                throw new InvalidEntryException(trimmedEntry);
            }
            
            Sandwich sandwich = parseSandwich(trimmedEntry.Substring(spaceIndex + 1));
            for (int i = 0; i < sandwichQuantity; i++) result.Add(sandwich);
        });
        return result;
    }

    private Sandwich parseSandwich(string sandwichString)
    {
        string trimmedEntry = sandwichString.Trim();
        int spaceIndex = trimmedEntry.IndexOf(" ", StringComparison.Ordinal);
        if (spaceIndex == -1) throw new InvalidEntryException(trimmedEntry);
        string details = trimmedEntry.Substring(spaceIndex + 1).Trim();
        SandwichBuilder builder = new SandwichBuilder();
        Console.WriteLine($"{details} is the det");
        Sandwich sandwich;
        // Check if got a custom sandwich
        if (details.Contains(':'))
        {
            List<String> ingredients = details.Split(' ').ToList();
            foreach (var i in ingredients)
            {
                List<String> quantityIngredient = i.Split(':').ToList();
                if (quantityIngredient.Count != 2) throw new InvalidEntryException(trimmedEntry);
                Quantity q = DataStore.quantityFromString(quantityIngredient[1]);
                Ingredient ingredient = DataStore.getIngredientByName(quantityIngredient[0]);
                builder.WithIngredient(ingredient, q);
            }
            sandwich = builder.Build();
            sandwich.Price = DataStore.getCustomSandwichPrice(sandwich);

        } 
        // Well known sandwich
        else {
            string sandwichName = trimmedEntry.Substring(spaceIndex + 1);
            sandwich = builder.WithName(sandwichName).Build();
        }
        return sandwich;
    }
}