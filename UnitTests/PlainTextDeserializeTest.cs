using Domain.Core;
using Client.Input;
using Client.InputHandler;

namespace UnitTests;

public class PlainTextDeserializeTest
{
    public void TestMultilineOrderPlainText()
    {
        var plainText = @"
            1 Pain:2 Oeuf:1 Thon:30_g
            3 Pain:2 Tranche_de_jambon:40 Salade:10_g
        ";
        PlainFileInputHandler handler = new PlainFileInputHandler(new PlainFileInput(""));
        Order order = handler.handle();
        
    }
}