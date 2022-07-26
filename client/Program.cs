using System;
using Domain.Core;
using Client.Output;
using Client.InputHandler;

namespace Client;

public class Program
{
    private Menu _menu;
    private InputHandlerFactory _inputFactory = new InputHandlerFactory();
    private OutputStrategyFactory _outputStrategyFactory = new OutputStrategyFactory();
    
    private static string DEFAULT_FILE_LOCATION = "./output/bill";
    
    public Program(Menu menu)
    {
        _menu = menu;
    }

    public static int Main()
    {
        DataStore dataStore = DataStore.Instance;
        Program program = new Program(dataStore);
        program.Launch();
        return 0;
    }

    public void Launch()
    {
        DisplayWelcome();
        while (true)
        {
            try
            {
                string? entry = Console.ReadLine();
                if (entry is null)
                {
                    throw new Exception("Vous avez fait une erreur de saisie, bande de malpropres");
                }

                List<string> args = entry.Split("-o").ToList();
                if (args.Count != 2)
                {
                    throw new Exception("Vous avez fait une erreur de saisie, bande de malpropres");
                }

                Order order = HandleInput(args[0].Trim());
                IOutputStrategy outputStrategy = _outputStrategyFactory.getStrategy(args[1].Trim(), DEFAULT_FILE_LOCATION);
                Bill bill = GenerateBill(order);
                HandleOutput(bill, outputStrategy);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }

    private void DisplayWelcome()
    {
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
    private Order HandleInput(string entry)
    {
        IInputHandler inputHandler = _inputFactory.getHandler(entry);
        return inputHandler.getOrder();
    }

    private Bill GenerateBill(Order order)
    {
        return order.Sandwiches.Aggregate(new Bill(), (bill, sandwich) => {
            bill.AddSandwich(sandwich);
            return bill;
        });
    }
    
    private void HandleOutput(Bill bill, IOutputStrategy outputStrategy)
        => outputStrategy.DisplayOutput(bill);
}