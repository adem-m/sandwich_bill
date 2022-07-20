using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable]
public class IngredientDto
{
    [JsonPropertyName("name")] [XmlElement("name")]
    public string Name { get; set; }

    [JsonPropertyName("quantity")] [XmlElement("quantity")]
    public string Quantity { get; set; }
    
    public IngredientDto(string name, string quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
    public IngredientDto()
    {
        Name = "";
        Quantity = "";
    }

}