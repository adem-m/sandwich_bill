using Xunit;
using Domain.Core;
using Domain.Exceptions;

namespace UnitTests;

public class SandwichBuilderTest
{
    [Fact]
    public void Should_build_a_sandwich()
    {
        var builder = new SandwichBuilder();
        var s = builder
            .WithName("sandwich")
            .WithPrice(new Price(10.0m, "EUR"))
            .WithIngredient(
                new Ingredient("ingredient1"),
                new Quantity(10.0m, "kg")
            )
            .Build();

        Assert.IsType<Sandwich>(s);
        Assert.Equal("sandwich", s.Name);
        Assert.Equal(new Price(10.0m, "EUR"), s.Price);
        Assert.Equal(1, s.Ingredients.Count);
    }

    [Fact]
    public void Should_not_build_when_name_is_missing()
    {
        var builder = new SandwichBuilder();
        Assert.Throws<SandwichArgumentException>(() => builder
            .WithPrice(new Price(10.0m, "EUR"))
            .WithIngredient(
                new Ingredient("ingredient1"),
                new Quantity(10.0m, "kg")
            )
            .Build());
    }

    [Fact]
    public void Should_not_build_when_price_is_missing()
    {
        var builder = new SandwichBuilder();
        Assert.Throws<SandwichArgumentException>(() => builder
            .WithName("sandwich")
            .WithIngredient(
                new Ingredient("ingredient1"),
                new Quantity(10.0m, "kg")
            )
            .Build());
    }

    [Fact]
    public void Should_not_build_when_ingredients_is_empty()
    {
        var builder = new SandwichBuilder();
        Assert.Throws<SandwichArgumentException>(() => builder
            .WithName("sandwich")
            .WithPrice(new Price(10.0m, "EUR"))
            .Build());
    }
}