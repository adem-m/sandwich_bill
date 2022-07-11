using Client.input;

namespace Domain.Core.handlers;

public class FactoryInputHandler {
    
    private readonly InputType _inputType;

    public FactoryInputHandler(InputType inputType)
    {
        _inputType = inputType;
    }

    public Order handle(string input)
    {
        switch (_inputType)
        {
            case InputType.Text:
                return getOrder(new PlainInput(input));
            case InputType.TextFile:
                return getOrder(new PlainFileInput(input));
            case InputType.Json:
                return getOrder(new JsonFileInput(input));
            case InputType.Xml:
                return getOrder(new XmlFileInput(input));
            default:
                throw new ArgumentOutOfRangeException();
        }
    } 
        
    private Order getOrder(PlainInput input)
    {
        IInputHandler handler = new PlainInputHandler(input);
        return handler.handle();
    }

    private Order getOrder(PlainFileInput input)
    {
        IInputHandler handler = new PlainFileInputHandler(input);
        return handler.handle();
    }
    
    private Order getOrder(JsonFileInput input) {
        IInputHandler handler = new JsonFileInputHandler(input);
        return handler.handle();
    }

    private Order getOrder(XmlFileInput input)
    {
        IInputHandler handler = new XmlFileInputHandler(input);
        return handler.handle();
    }
    
}