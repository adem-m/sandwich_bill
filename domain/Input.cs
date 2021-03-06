namespace Domain.Core;

public interface Input
{
}

public class PlainInput : Input
{
    public string Content { get; set; }
    public PlainInput(string content)
    {
        Content = content;
    }
}

public class PlainFileInput : Input
{
    public string FileName { get; set; }
    public PlainFileInput(string fileName)
    {
        FileName = fileName;
    }
}

public class JsonFileInput : Input
{
    public string FileName { get; set; }
    public JsonFileInput(string fileName)
    {
        FileName = fileName;
    }
}

public class XmlFileInput : Input
{
    public string FileName { get; set; }
    public XmlFileInput(string fileName)
    {
        FileName = fileName;
    }
}
