namespace Domain;

public class Ingredient 
{
    public string Name { get; private set; }

    public Ingredient(string name)
    {
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Ingredient)
        {
            return false;
        }
        return ((Ingredient) obj).Name == Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() + Name.GetHashCode();
    }

    public override string ToString() => $"{Name}(s)";
}