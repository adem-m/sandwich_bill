using Domain.Core;

namespace Client.output;

public interface IOutputStrategy
{
    void DisplayOutput(Bill bill);
}