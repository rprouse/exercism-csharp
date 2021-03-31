using Xunit;
using System.Collections.Generic;


public class SumOfMultiplesTest
{
    private SumOfMultiples sumOfMultiples;

    public SumOfMultiplesTest()
    {
        sumOfMultiples = new SumOfMultiples();
    }

    [Fact]
    public void Sum_to_1()
    {
        Assert.Equal(0, sumOfMultiples.To(1));
    }

    [Fact]
    public void Sum_to_3()
    {
        Assert.Equal(3, sumOfMultiples.To(4));
    }

    [Fact]
    public void Sum_to_10()
    {
        Assert.Equal(23, sumOfMultiples.To(10));
    }

    [Fact]
    public void Sum_to_16()
    {
        Assert.Equal(60, sumOfMultiples.To(16));
    }

    [Fact]
    public void Sum_to_1000()
    {
        Assert.Equal(233168, sumOfMultiples.To(1000));
    }

    [Fact]
    public void Configurable_7_13_17_to_20()
    {
        Assert.Equal(51, new SumOfMultiples(new List<int> { 7, 13, 17 }).To(20));
    }

    [Fact]
    public void Configurable_43_47_to_10000()
    {
        Assert.Equal(2203160, new SumOfMultiples(new List<int> { 43, 47 }).To(10000));
    }
}