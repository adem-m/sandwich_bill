using Domain.Core;
using Client.Input;
namespace Client.InputHandler;

public class InputHandlerFactory {
    public IInputHandler getHandler(string input)
    {
        if (input.EndsWith(".txt"))
        {
            return new PlainFileInputHandler(new PlainFileInput(input));
        } 
        if(input.EndsWith(".json"))
        {
            return new JsonFileInputHandler(new JsonFileInput(input));
        }
        if(input.EndsWith(".xml"))
        {
            return new XmlFileInputHandler(new XmlFileInput(input));
        }
        return new PlainInputHandler(new PlainInput(input));
    }   
}