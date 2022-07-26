using Domain.Exceptions;
using Domain.Core;
using Xunit;

namespace UnitTests;

public class BillTest
{
    private static Sandwich SANDWICH = new SandwichBuilder()
        .WithName("Sandwich")
        .WithIngredient(new Ingredient("BREAD"), new Quantity(1))
        .WithIngredient(new Ingredient("HAM"), new Quantity(1))
        .WithPrice(new Price(2, "EUR"))
        .Build();

    [Fact]
    public void ShouldContainsOneSandwichWhenAdded()
    {
        Bill bill = new();
        bill.AddSandwich(SANDWICH);

        Assert.Single(bill.sandwiches);
        Assert.True(bill.sandwiches.ContainsKey(SANDWICH));
    }

    [Fact]
    public void ShouldContainsZeroSandwichesWhenEmpty()
    {
        Bill bill = new();

        Assert.Empty(bill.sandwiches);
    }

    [Fact]
    public void ShouldContainsOneSandwichWhenAddedTwice()
    {
        Bill bill = new();
        bill.AddSandwich(SANDWICH);
        bill.AddSandwich(SANDWICH);

        Assert.Single(bill.sandwiches);
        Assert.True(bill.sandwiches.ContainsKey(SANDWICH));
        Assert.StrictEqual(2, bill.sandwiches[SANDWICH]);
    }

    [Fact]
    public void ShouldThrowExceptionWhenRemovingNonExistingSandwich()
    {
        Bill bill = new();

        Assert.Throws<SandwichNotInBillException>(() => bill.RemoveSandwich(SANDWICH));
    }

    [Fact]
    public void ShouldCalculateTotalPriceWhenOneSandwich()
    {
        Bill bill = new();
        bill.AddSandwich(SANDWICH);

        Assert.StrictEqual(2m, bill.Total().Value);
    }

    [Fact]
    public void ShouldPrintBillWhenOneSandwich()
    {
        Bill bill = new();
        bill.AddSandwich(SANDWICH);

        string expectedOutput = "1 Sandwich: \n \t1 BREAD(s) \n\t1 HAM(s) \n \nPrix total: EUR 2";

        Assert.Equal(expectedOutput, bill.ToString());
    }
}