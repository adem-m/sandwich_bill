using Xunit;
using Domain.Core;
using Domain.Exceptions;

namespace UnitTests;

public class QuantityTest
{
    [Fact]
    public void Should_create_a_price()
    {
        var q = new Quantity(10.0m, "kg");

        Assert.IsType<Quantity>(q);
        Assert.Equal(10.0m, q.Value);
        Assert.Equal("kg", q.Unit);
    }

    [Fact]
    public void Should_create_a_price_without_a_unit()
    {
        var q = new Quantity(10.0m);

        Assert.IsType<Quantity>(q);
        Assert.Equal(10.0m, q.Value);
        Assert.Null(q.Unit);
    }

    [Fact]
    public void Should_add_quantities()
    {
        var q1 = new Quantity(10.0m, "kg");
        var q2 = new Quantity(20.0m, "kg");
        var q3 = q1 + q2;

        Assert.IsType<Quantity>(q3);
        Assert.Equal(q1.Value + q2.Value, q3.Value);
        Assert.Equal(q1.Unit, q3.Unit);
    }

    [Fact]
    public void Should_not_add_quantities_of_different_units()
    {
        var q1 = new Quantity(10.0m, "kg");
        var q2 = new Quantity(20.0m, "m3");

        Assert.Throws<InvalidQuantityOperation>(() => q1 + q2);
    }
}