namespace Domain.Core;

public readonly struct Ingredient
{
    public string Name { get; init; }

    public Ingredient(string name)
    {
        Name = name;
    }

    public override string ToString() => $"{Name}(s)";
}