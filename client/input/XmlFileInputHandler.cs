using System.Xml.Serialization;
using Client.Exceptions;
using Client.exposition.mapper;

namespace Domain.Core.handlers;

public class XmlFileInputHandler : IInputHandler
{
    private readonly XmlFileInput _input;
    
    public XmlFileInputHandler(XmlFileInput input)
    {
        _input = input;
    }
    public Order handle()
    {
        OrderListDTO? orderDtoList;
        XmlSerializer serializer = new XmlSerializer(typeof(OrderListDTO));
        using (StreamReader r = new StreamReader(_input.FileName))
        {
            orderDtoList = (OrderListDTO)serializer.Deserialize(r)!;
        }
        if (orderDtoList == null) throw new InvalidJsonEntryException();
        return OrderMapper.toOrder(orderDtoList);
    }
}