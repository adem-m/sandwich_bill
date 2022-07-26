using Domain.Core;
namespace Client.Input;

public interface IInputHandler
{
    Order handle();
}