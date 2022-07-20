using Client;

namespace Domain.Core.handlers;

public class PlainInputHandler : IInputHandler
{
    private DataStore _dataStore;

    private readonly PlainInput _input;

    public PlainInputHandler( PlainInput input)
    {
        _dataStore = DataStore.Instance;
        _input = input;
    }
    public Order handle()
    {
        TextInputParser textInputParser = new TextInputParser();
        return new Order(textInputParser.ParseLine(_input.Content));
    }
}