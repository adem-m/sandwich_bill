using Domain.Core;
namespace Client.InputHandlers;

public interface IInputHandler
{
    Order getOrder();
}