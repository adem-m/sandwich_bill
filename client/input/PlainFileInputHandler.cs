using Client;

namespace Domain.Core.handlers;

public class PlainFileInputHandler : IInputHandler
{
    private static readonly DataStore DataStore = DataStore.Instance;
    
    private PlainFileInput Input { get; }
    
    public PlainFileInputHandler(PlainFileInput input)
    {
        Input = input;
    }

    public Order handle()
    {
        List<Sandwich> sandwiches = new List<Sandwich>();
        TextInputParser inputParser = new TextInputParser();
        foreach (string line in System.IO.File.ReadLines(Input.FileName))
        {
            List<Sandwich> sandwich = inputParser.ParseLine(line);
            sandwich.ForEach(s => Console.WriteLine(s.Ingredients[0].Item1.Name));
            sandwiches.Concat(sandwich);
        }
        return new Order(sandwiches);
    }
}