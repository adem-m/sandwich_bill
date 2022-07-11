using System.Xml.Serialization;
using Domain.Core;
using Domain.Core.handlers;

namespace Client.output;

public class XmlFileOutputStrategy : IOutputStrategy
{
    private readonly string _fileLocation;
    
    public XmlFileOutputStrategy(string fileLocation)
    {
        _fileLocation = fileLocation;
    }

    public void DisplayOutput(Bill bill)
    {   
        XmlSerializer serializer = new XmlSerializer(typeof(BillDTO));
        using TextWriter writer = new StreamWriter(_fileLocation);
        serializer.Serialize(writer, bill);
    }
}