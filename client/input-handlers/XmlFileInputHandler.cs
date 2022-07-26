using System.Xml.Serialization;
using Client.Exceptions;
using Domain.Core;
using Client.DTOs;
using Client.Mappers;

namespace Client.InputHandlers;

public class XmlFileInputHandler : IInputHandler
{
    private readonly string _filepath;
    
    public XmlFileInputHandler(string filepath)
    {
        _filepath = filepath;
    }
    public Order getOrder()
    {
        OrderListDto? orderDtoList;
        XmlSerializer serializer = new XmlSerializer(typeof(OrderListDto));
        using (StreamReader r = new StreamReader(_filepath))
        {
            orderDtoList = (OrderListDto)serializer.Deserialize(r)!;
        }
        if (orderDtoList == null) throw new InvalidJsonEntryException();
        return OrderMapper.ToOrder(orderDtoList);
    }
}