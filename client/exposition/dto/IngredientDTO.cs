using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable]
public class IngredientDTO
{
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("quantity")]
    [XmlElement("quantity")]
    public string Quantity { get; set; }
    
    [JsonConstructor]
    public IngredientDTO(string name, string quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
}