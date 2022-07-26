namespace Client.Input;

public class JsonFileInput : IInput
{
    public string FileName { get; set; }
    public JsonFileInput(string fileName)
    {
        FileName = fileName;
    }
}