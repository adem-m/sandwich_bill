using System.Text.Json;
using Domain.Core;
using Domain.Core.handlers;

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
        string json = JsonSerializer.Serialize(BillMapper.ToBillDto(bill));
        File.WriteAllText(_fileLocation, json);
        Console.WriteLine($"Bill saved at {_fileLocation}");
    }
}