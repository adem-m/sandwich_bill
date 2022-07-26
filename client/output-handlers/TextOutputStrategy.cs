using Domain.Core;

namespace Client.OutputHandlers;

public class TextOutputStrategy : IOutputStrategy
{
    public void DisplayOutput(Bill bill)
    {
        Console.WriteLine(bill.ToString());
    }
}