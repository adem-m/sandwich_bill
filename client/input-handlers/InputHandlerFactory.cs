namespace Client.InputHandlers;

public class InputHandlerFactory {
    public IInputHandler getHandler(string input)
    {
        if (input.EndsWith(".txt"))
        {
            return new PlainFileInputHandler(input);
        } 
        if(input.EndsWith(".json"))
        {
            return new JsonFileInputHandler(input);
        }
        if(input.EndsWith(".xml"))
        {
            return new XmlFileInputHandler(input);
        }
        return new PlainInputHandler(input);
    }   
}