using Client.input;
using Client.output;
using Domain.Core.handlers;

namespace Client;

using System;
using System.Collections.Generic;
using Domain.Core;

public class Program
{
    private TextInputParser _textInputParser = new();
    private Menu _menu;
    private InputType? _inputType;
    private FactoryInputHandler? _inputFactory;
    
    private static string DEFAULT_FILE_LOCATION = "./output/bill";
    
    public Program(Menu menu)
    {
        _menu = menu;
        _inputFactory = null;
        _inputType = null;
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
                order = HandleInput();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            Bill bill = GenerateBill(order);
            HandleOutput(bill);
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

    private void InferInputType(string input)
    {
        if (!input.Contains('/'))
        {
            _inputType = InputType.Text;
            return;
        } 
        if(input.EndsWith(".json"))
        {
            _inputType = InputType.Json;
            return;
        }
        if(input.EndsWith(".xml"))
        {
            _inputType = InputType.Xml;
            return;
        }
        _inputType = InputType.Text;
    }
    
    private Order HandleInput()
    {
        string? entry = Console.ReadLine();
        if (entry == null)
        {
            throw new Exception("Vous avez fait une erreur de saisie, bande de malpropres");
        }
        InferInputType(entry);
        if (_inputType == null) throw new Exception("Input type not set");
        _inputFactory = new FactoryInputHandler(_inputType.Value);
        return _inputFactory.handle(entry);
    }

    private Bill GenerateBill(Order order)
    {
        return order.Sandwiches.Aggregate(new Bill(), (bill, sandwich) => {
            bill.AddSandwich(sandwich);
            return bill;
        });
    }
    
    private void HandleOutput(Bill bill)
    {
        IOutputStrategy strategy = null;
        switch (_inputType)
        {
            case InputType.TextFile:
                strategy = new TextOutputStrategy();
                break;
            case InputType.Json:
                strategy = new JsonFileOutputStrategy(DEFAULT_FILE_LOCATION + ".json");
                break;
            case InputType.Xml:
                strategy = new XmlFileOutputStrategy(DEFAULT_FILE_LOCATION + ".xml");
                break;
            case InputType.Text:
                strategy = new TextFileOutputStrategy(DEFAULT_FILE_LOCATION + ".txt");
                break;
            default:
                throw new Exception("Input type not set");
        }
        strategy?.DisplayOutput(bill);
    }
}