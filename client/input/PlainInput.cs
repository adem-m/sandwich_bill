namespace Client.Input;

public class PlainInput : IInput
{
    public string Content { get; set; }
    public PlainInput(string content)
    {
        Content = content;
    }
}