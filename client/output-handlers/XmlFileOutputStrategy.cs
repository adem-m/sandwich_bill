using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using Domain.Core;
using Client.DTOs;
using Client.Mappers;

namespace Client.OutputHandlers;

public class XmlFileOutputStrategy : IOutputStrategy
{
    private readonly string _fileLocation;
    private readonly XmlWriterSettings _settings = new XmlWriterSettings()
    {
        Indent = true,
        IndentChars = "\t"
    };
    
    public XmlFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }

    public void DisplayOutput(Bill bill)
    {   
        XmlSerializer serializer = new XmlSerializer(typeof(BillDto));
        using var writer = XmlWriter.Create(_fileLocation, _settings);
        serializer.Serialize(writer, BillMapper.ToBillDto(bill));
        Console.WriteLine($"Bill saved at {_fileLocation}");
    }
    
}