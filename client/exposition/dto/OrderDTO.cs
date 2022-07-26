using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Client.DTOs;

[Serializable]
public class OrderDto
{
    [JsonPropertyName("quantity")] [XmlElement("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("name")] [XmlElement("name")]
    public string? Name { get; set; }

    [XmlArray(ElementName = "ingredients")] [XmlArrayItem("ingredient", Type = typeof(IngredientDto))]
    [JsonPropertyName("ingredients")]
    public List<IngredientDto>? Ingredients { get; set; }

    public OrderDto()
    {
        Quantity = -1;
    }
}