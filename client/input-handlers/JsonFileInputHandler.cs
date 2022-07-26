using System.Text.Json;
using Client.Exceptions;
using Client.Mappers;
using Client.DTOs;
using Domain.Core;

namespace Client.InputHandlers;

public class JsonFileInputHandler : IInputHandler
{
    private static readonly DataStore DataStore = DataStore.Instance;

    private readonly string _filepath;
    
    public JsonFileInputHandler(string filepath)
    {
        _filepath = filepath;
    }

    public Order getOrder() {
        OrderListDto? orderDtoList;
        using (var r = new StreamReader(_filepath))
        {
            string json = r.ReadToEnd();
            orderDtoList = JsonSerializer.Deserialize<OrderListDto>(json);
        }
        if (orderDtoList == null) throw new InvalidJsonEntryException();
        return OrderMapper.ToOrder(orderDtoList);
    }
}