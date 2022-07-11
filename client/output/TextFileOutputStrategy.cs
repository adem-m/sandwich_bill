using Domain.Core;

namespace Client.output;

public class TextFileOutputStrategy : IOutputStrategy
{
    
    private readonly string _fileLocation;

    public TextFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }

    public void DisplayOutput(Bill bill)
    {
        string content = bill.ToString();
        File.WriteAllText(_fileLocation, content);
    }
}