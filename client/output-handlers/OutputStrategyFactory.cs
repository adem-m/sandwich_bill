using System;
namespace Client.OutputHandlers;

public class OutputStrategyFactory
{
    public IOutputStrategy getStrategy(string name, string fileLocation)
    {
        return name switch 
        {
            "text" => new TextFileOutputStrategy(fileLocation + ".txt"),
            "json" => new JsonFileOutputStrategy(fileLocation + ".json"),
            "xml" => new XmlFileOutputStrategy(fileLocation + ".xml"),
            "console" => new TextOutputStrategy(),
            _ => throw new InvalidOperationException("Francky Vincent ne connaît pas ce format de sortie, dégagez du resto !")
        };
    }
}