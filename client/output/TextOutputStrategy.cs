using Domain.Core;

namespace Client.output;

public class TextOutputStrategy : IOutputStrategy
{
    public void DisplayOutput(Bill bill)
    {
        Console.WriteLine(bill.ToString());
    }
}