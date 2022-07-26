using Domain.Core;

namespace Client.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using Client.Exceptions;

public class TextInputParser
{
    private DataStore DataStore { get; set; }
    
    public TextInputParser()
    {
        DataStore = DataStore.Instance;
    }
    
    public List<Sandwich> ParseLine(String line)
    {
        List<string> orderListString = line.Split(",").ToList();
        List<Sandwich> result = new List<Sandwich>();
        orderListString.ForEach(entry =>
        {
            string trimmedEntry = entry.Trim();
            int spaceIndex = trimmedEntry.IndexOf(" ", StringComparison.Ordinal);
            if (spaceIndex == -1) throw new InvalidEntryException(trimmedEntry);

            string stringQuantity = trimmedEntry.Substring(0, spaceIndex);

            int sandwichQuantity;
            try
            {
                sandwichQuantity = int.Parse(stringQuantity);
            }
            catch (FormatException)
            {
                throw new InvalidEntryException(trimmedEntry);
            }
            Sandwich sandwich = ParseSandwich(trimmedEntry.Substring(spaceIndex + 1));
            for (int i = 0; i < sandwichQuantity; i++) result.Add(sandwich);
            result.Add(sandwich);
        });
        return result;
    }

    private  Sandwich ParseSandwich(string sandwichString)
    {
        string details /*trimmedEntry*/ = sandwichString.Trim();
        // int spaceIndex = trimmedEntry.IndexOf(" ", StringComparison.Ordinal);
        // if (spaceIndex == -1) throw new InvalidEntryException(trimmedEntry);
        // string details = trimmedEntry.Substring(spaceIndex + 1).Trim();
        Sandwich sandwich;
        // Check if got a custom sandwich
        if (details.Contains(':'))
        {
            sandwich = DataStore.createSandwich(details);
        } 
        // Well known sandwich
        else
        {
            sandwich = DataStore.getByName(details);
        }
        return sandwich;
    }
}