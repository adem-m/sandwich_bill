using System;
using System.Collections.Generic;
using System.Linq;

namespace Client;

public class Parser
{
    public List<String> Parse(string orderString)
    {
        List<string> orderListString = orderString.Split(",").ToList();
        List<String> result = new List<string>();
        orderListString.ForEach(entry =>
        {
            string trimmedEntry = entry.Trim();
            int spaceIndex = trimmedEntry.IndexOf(" ", StringComparison.Ordinal);
            if (spaceIndex == -1) throw new InvalidEntryException(trimmedEntry);

            string stringQuantity = trimmedEntry.Substring(0, spaceIndex);
            string sandwichName = trimmedEntry.Substring(spaceIndex + 1);

            int quantity;
            try
            {
                quantity = int.Parse(stringQuantity);
            }
            catch (FormatException)
            {
                throw new InvalidEntryException(trimmedEntry);
            }

            for (int i = 0; i < quantity; i++) result.Add(sandwichName);
        });
        return result;
    }
}