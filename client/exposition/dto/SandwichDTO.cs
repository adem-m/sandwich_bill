using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Client.DTOs;

[Serializable]
public class SandwichDto
{
    [JsonPropertyName("quantity")] [XmlElement("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("name")] [XmlElement("name")]
    public string? Name { get; set; }

    [JsonPropertyName("ingredients")]
    [XmlArray(ElementName = "ingredients")]
    [XmlArrayItem("ingredient", Type = typeof(IngredientDto))]
    public List<IngredientDto> Ingredients { get; set; }
    
    [JsonConstructor]
    public SandwichDto(int quantity, List<IngredientDto> ingredients)
    {
        Quantity = quantity;
        Ingredients = ingredients;
    }
    
    public SandwichDto()
    {
        Quantity = 0;
        Name = "";
        Ingredients = new List<IngredientDto>();
    }
}