using System.ComponentModel.Design;

namespace Client;

using System;
public class Program {

    private Parser _parser = new Parser();
    public static void Run()
    {
        Program program = new Program();
        program.Launch();
    }

    public void Launch()
    {
        DisplayWelcome();
        HandleCommands();
    }

    private void DisplayWelcome() {
        string banner = @"
         _____                     _           __     ___                      _       
        |  ___| __ __ _ _ __   ___| | ___   _  \ \   / (_)_ __   ___ ___ _ __ | |_   _ 
        | |_ | '__/ _` | '_ \ / __| |/ / | | |  \ \ / /| | '_ \ / __/ _ \ '_ \| __| (_)
        |  _|| | | (_| | | | | (__|   <| |_| |   \ V / | | | | | (_|  __/ | | | |_   _ 
        |_|  |_|  \__,_|_| |_|\___|_|\_\\__, |    \_/  |_|_| |_|\___\___|_| |_|\__| (_)
                                        |___/                                          
         _           ____           _                              _   
        | |    ___  |  _ \ ___  ___| |_ __ _ _   _ _ __ __ _ _ __ | |_ 
        | |   / _ \ | |_) / _ \/ __| __/ _` | | | | '__/ _` | '_ \| __|
        | |__|  __/ |  _ <  __/\__ \ || (_| | |_| | | | (_| | | | | |_ 
        |_____\___| |_| \_\___||___/\__\__,_|\__,_|_|  \__,_|_| |_|\__|";
        banner += "\n\nTapez vos commandes ici, bande de malpropres :";
        Console.WriteLine(banner);
    }

    private void HandleCommands()
    {
        bool otherCommand = true;
        string valueEntry;
        while (otherCommand) {
            valueEntry = Console.ReadLine();
            if(valueEntry == "") return;
            Console.WriteLine("Value = valueEntry");
            _parser.AddSandwichList(valueEntry);
        }

        Console.WriteLine(_parser.menu.ToString());
    }
}
