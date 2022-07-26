using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Client.DTOs;


[Serializable]
[XmlRoot("root")]
public class BillDto
{
    [JsonPropertyName("sandwiches")]
    [XmlArray(ElementName="sandwiches")]
    [XmlArrayItem("sandwich", Type=typeof(SandwichDto))]
    public List<SandwichDto> Sandwiches { get; set; }

    [JsonPropertyName("currency")] [XmlElement("currency")]
    public string Currency{ get; set; }

    [JsonPropertyName("amount")] [XmlElement("amount")]
    public decimal Amount{ get; set; }

    public BillDto(List<SandwichDto> sandwiches, string currency, decimal amount)
    {
        Sandwiches = sandwiches;
        Currency = currency;
        Amount = amount;
    }
    
    public BillDto()
    {
        Sandwiches = new List<SandwichDto>();
        Currency = "€";
        Amount = 0;
    }
}