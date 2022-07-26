using Domain.Core;

namespace Client.InputHandlers;

public class PlainInputHandler : IInputHandler
{
    private DataStore _dataStore;

    private readonly string _input;

    public PlainInputHandler(string input)
    {
        _dataStore = DataStore.Instance;
        _input = input;
    }
    public Order getOrder()
    {
        TextInputParser textInputParser = new TextInputParser();
        return new Order(textInputParser.ParseLine(_input));
    }
}