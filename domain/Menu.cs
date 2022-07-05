namespace Domain.Core;

public interface Menu
{
    void AddEntry(Sandwich sandwich);
    Sandwich getByName(string name);
}