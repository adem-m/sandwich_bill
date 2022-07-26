using Domain.Core;

namespace Client.InputHandlers;

public class PlainFileInputHandler : IInputHandler
{
    private static readonly DataStore DataStore = DataStore.Instance;
    
    private readonly string _filepath;
    
    public PlainFileInputHandler(string filepath)
    {
        _filepath = filepath;
    }

    public Order getOrder()
    {
        List<Sandwich> sandwiches = new List<Sandwich>();
        TextInputParser inputParser = new TextInputParser();
        foreach (string line in File.ReadLines(_filepath))
        {
            List<Sandwich> sandwich = inputParser.ParseLine(line);
            sandwiches.AddRange(sandwich);
        }
        return new Order(sandwiches);
    }
}