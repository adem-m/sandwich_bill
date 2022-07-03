using System;

namespace Client.Exceptions;

public class InvalidEntryException : Exception
{
    public InvalidEntryException(string entry) : base($"L'entrée \"{entry}\" n'est pas correcte espèce de cochon ! \n" +
                                                      "Elle doit prendre la forme : <quantité> <nom_sandwich>")
    {
    }
}