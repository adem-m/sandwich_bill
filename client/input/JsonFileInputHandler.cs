using System.Text.Json;
using Client.Exceptions;
using Client.exposition.mapper;

namespace Domain.Core.handlers;

public class JsonFileInputHandler : IInputHandler
{
    private static readonly DataStore DataStore = DataStore.Instance;

    private JsonFileInput _input { get; }
    
    public JsonFileInputHandler( JsonFileInput input)
    {
        _input = input;
    }

    public Order handle() {
        OrderListDto? orderDtoList;
        using (var r = new StreamReader(_input.FileName))
        {
            string json = r.ReadToEnd();
            orderDtoList = JsonSerializer.Deserialize<OrderListDto>(json);
        }
        if (orderDtoList == null) throw new InvalidJsonEntryException();
        return OrderMapper.ToOrder(orderDtoList);
    }
}