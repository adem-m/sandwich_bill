using Domain.Core.handlers;

namespace Client;

using System;
using System.Collections.Generic;
using Domain.Core;

public class Program
{
    private Parser _parser = new();
    private Menu _menu;

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
            Order order;
            try
            {
                order = GetOrder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            Bill bill = GenerateBill(order);
            DisplayBill(bill);
        }
    }

    private void DisplayBill(Bill bill)
    {
        Console.WriteLine(bill.ToString());
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

    private Order GetOrder()
    {
        string? entry = Console.ReadLine();
        if (entry == null)
        {
            throw new Exception("Vous avez fait une erreur de saisie, bande de malpropres");
        }
        PlainInputHandler plainInputHandler = new PlainInputHandler(new PlainInput(entry));
        Order order = plainInputHandler.handle();

        /*List<String> sandwichNames = _parser.Parse(entry);

        List<Sandwich> sandwiches = sandwichNames.ConvertAll(sandwich => _menu.createSandwich(sandwich));

        return new Order(sandwiches);*/
        return order;
    }

    private Bill GenerateBill(Order order)
    {
        return order.Sandwiches.Aggregate(new Bill(), (bill, sandwich) => {
            bill.AddSandwich(sandwich);
            return bill;
        });
    }
}