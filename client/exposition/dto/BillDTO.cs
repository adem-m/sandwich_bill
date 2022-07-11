using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;


[Serializable()]
[XmlRoot("root")]
public class BillDTO
{
    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public string Currency { get; set; }
    
    [JsonPropertyName("amount")]
    [XmlElement("amount")]
    public decimal Amount { get; set; }
    
    [JsonPropertyName("sandwiches")]
    [XmlArray(ElementName="sandwiches")]
    [XmlArrayItem("sandwich", Type=typeof(SandwichDTO))]
    public List<SandwichDTO> Sandwiches;
    
    [JsonConstructor]
    public BillDTO(List<SandwichDTO> sandwiches, string currency, decimal amount)
    {
        Sandwiches = sandwiches;
        Currency = currency;
        Amount = amount;
    }
}