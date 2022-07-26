using System.Text.Json;
using Domain.Core;
using Client.Mappers;

namespace Client.OutputHandlers;

public class JsonFileOutputStrategy : IOutputStrategy
{
    private readonly string _fileLocation;
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        WriteIndented = true
    };
    
    public JsonFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }
    
    public void DisplayOutput(Bill bill)
    {

        string json = JsonSerializer.Serialize(BillMapper.ToBillDto(bill), _options);
        File.WriteAllText(_fileLocation, json);
        Console.WriteLine($"Bill saved at {_fileLocation}");
    }
}