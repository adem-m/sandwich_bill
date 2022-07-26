using System.Xml.Serialization;
using Client.Exceptions;
using Domain.Core;
using Client.DTOs;
using Client.Mappers;
using Client.Input;

namespace Client.InputHandler;

public class XmlFileInputHandler : IInputHandler
{
    private readonly XmlFileInput _input;
    
    public XmlFileInputHandler(XmlFileInput input)
    {
        _input = input;
    }
    public Order getOrder()
    {
        OrderListDto? orderDtoList;
        XmlSerializer serializer = new XmlSerializer(typeof(OrderListDto));
        using (StreamReader r = new StreamReader(_input.FileName))
        {
            orderDtoList = (OrderListDto)serializer.Deserialize(r)!;
        }
        if (orderDtoList == null) throw new InvalidJsonEntryException();
        return OrderMapper.ToOrder(orderDtoList);
    }
}