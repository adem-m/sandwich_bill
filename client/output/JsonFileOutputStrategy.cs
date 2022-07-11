using System.Text.Json;
using Domain.Core;

namespace Client.output;

public class JsonFileOutputStrategy : IOutputStrategy
{
    private readonly string _fileLocation;
    
    public JsonFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }
    
    public void DisplayOutput(Bill bill)
    {
        string json = JsonSerializer.Serialize(bill);
        File.WriteAllText(_fileLocation, json);
    }
}