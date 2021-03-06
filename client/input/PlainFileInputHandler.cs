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
        foreach (string line in File.ReadLines(Input.FileName))
        {
            List<Sandwich> sandwich = inputParser.ParseLine(line);
            sandwiches.AddRange(sandwich);
        }
        return new Order(sandwiches);
    }
}