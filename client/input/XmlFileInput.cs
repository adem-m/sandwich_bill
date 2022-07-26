namespace Client.Input;

public class XmlFileInput : IInput
{
    public string FileName { get; set; }
    public XmlFileInput(string fileName)
    {
        FileName = fileName;
    }
}