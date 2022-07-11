using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable]
public class OrderDTO
{
    [JsonPropertyName("quantity")]
    [XmlElement("quantity")]
    public int Quantity { get; set; }
    
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("ingredients")]
    [XmlArray(ElementName="ingredients")]
    [XmlArrayItem("ingredient", Type=typeof(IngredientDTO))]
    public List<IngredientDTO>? Ingredients { get; set; }
    
}