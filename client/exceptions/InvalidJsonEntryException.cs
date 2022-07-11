namespace Client.Exceptions;

public class InvalidJsonEntryException : Exception
{
    public InvalidJsonEntryException() : base("Francky pas content: le JSON fourni n'est pas bon.")
    {
    }
}