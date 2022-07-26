using Domain.Core;

namespace Client.Output;

public interface IOutputStrategy
{
    void DisplayOutput(Bill bill);
}