using Domain.Core;

namespace Client.Output;

public class TextOutputStrategy : IOutputStrategy
{
    public void DisplayOutput(Bill bill)
    {
        Console.WriteLine(bill.ToString());
    }
}