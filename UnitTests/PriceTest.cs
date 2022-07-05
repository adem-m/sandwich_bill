using Xunit;
using Domain.Core;
using Domain.Exceptions;

namespace UnitTests;

public class PriceTest
{
    [Fact]
    public void Should_create_a_price()
    {
        var p = new Price(10.0m, "EUR");
        Assert.IsType<Price>(p);
        Assert.Equal(10.0m, p.Value);
        Assert.Equal("EUR", p.Currency);
    }

    [Fact]
    public void Should_add_prices()
    {
        var p1 = new Price(10.0m, "EUR");
        var p2 = new Price(20.0m, "EUR");
        var p3 = p1 + p2;

        Assert.NotEqual(p1, p3);
        Assert.NotEqual(p2, p3);
        Assert.Equal(30.0m, p3.Value);
        Assert.Equal("EUR", p3.Currency);
    }

    [Fact]
    public void Should_not_add_prices_of_different_currencies()
    {
        var p1 = new Price(10.0m, "EUR");
        var p2 = new Price(20.0m, "USD");

        Assert.Throws<InvalidPriceOperation>(() => p1 + p2);
    }

    [Fact]
    public void Should_multiply_a_price()
    {
        var p1 = new Price(10.0m, "EUR");
        var r = p1 * 4;

        Assert.IsType<Price>(r);
        Assert.Equal(p1.Value * 4, r.Value);
        Assert.Equal(p1.Currency, r.Currency);
    }

    [Fact]
    public void Multiply_operator_should_be_commutative()
    {
        var p1 = new Price(10.0m, "EUR");
        var r1 = 3 * p1;
        var r2 = p1 * 3;

        Assert.Equal(r1, r2);
    }
}