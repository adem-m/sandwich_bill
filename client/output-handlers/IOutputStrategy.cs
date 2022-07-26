using Domain.Core;

namespace Client.OutputHandlers;

public interface IOutputStrategy
{
    void DisplayOutput(Bill bill);
}