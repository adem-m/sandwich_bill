using Domain.Core;
namespace Client.InputHandler;

public interface IInputHandler
{
    Order handle();
}