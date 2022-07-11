using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable()]
[XmlRoot("root")]
public class OrderListDTO
{
    [JsonPropertyName("orders")]
    [XmlArray(ElementName="orders")]
    [XmlArrayItem("order", Type=typeof(OrderDTO))]
    public List<OrderDTO> Orders { get; set; }
    
    [JsonConstructor]
    public OrderListDTO(List<OrderDTO> orders)
    {
        Orders = orders;
    }
}