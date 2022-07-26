using System.Xml.Linq;
using System.Xml.Serialization;
using Domain.Core;
using Client.DTOs;
using Client.Mappers;

namespace Client.Output;

public class XmlFileOutputStrategy : IOutputStrategy
{
    private readonly string _fileLocation;
    
    public XmlFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }

    public void DisplayOutput(Bill bill)
    {   
        XmlSerializer serializer = new XmlSerializer(typeof(BillDto));
        using TextWriter writer = new StreamWriter(_fileLocation);
        serializer.Serialize(writer, BillMapper.ToBillDto(bill));
        Console.WriteLine($"Bill saved at {_fileLocation}");
    }
    
}