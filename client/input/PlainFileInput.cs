namespace Client.Input;

public class PlainFileInput : IInput
{
    public string FileName { get; set; }
    public PlainFileInput(string fileName)
    {
        FileName = fileName;
    }
}