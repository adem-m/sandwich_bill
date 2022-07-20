using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Core.handlers;

[Serializable()]
[XmlRoot("root")]
public class OrderListDto
{
    [JsonPropertyName("orders")]
    [XmlArray(ElementName="orders")]
    [XmlArrayItem("order", Type=typeof(OrderDto))]
    public List<OrderDto> Orders { get; set; }
    
    [JsonConstructor]
    public OrderListDto(List<OrderDto> orders)
    {
        Orders = orders;
    }
    public OrderListDto()
    {
        Orders = new List<OrderDto>();
    }
}