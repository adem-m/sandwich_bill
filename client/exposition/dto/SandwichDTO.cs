using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable]
public class SandwichDTO
{
    [JsonPropertyName("quantity")]
    [XmlElement("quantity")]
    public int Quantity { get; set; }
    
    [JsonPropertyName("ingredients")]
    [XmlArray(ElementName="ingredients")]
    [XmlArrayItem("ingredient", Type=typeof(IngredientDTO))]
    public List<IngredientDTO> Ingredients { get; set; }
    
    [JsonConstructor]
    public SandwichDTO(int quantity, List<IngredientDTO> ingredients)
    {
        Quantity = quantity;
        Ingredients = ingredients;
    }
}