namespace Domain;

public class InvalidQuantityOperation : InvalidOperationException
{
    public InvalidQuantityOperation() : base("Attempting an invalid operation with quantities.") {}
}