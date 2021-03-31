using Xunit;


public class PrimeFactorsTest
{
    [Fact]
    public void Test_1()
    {
        Assert.Equal<long>(PrimeFactors.For(1), new long[0]);
    }

    [Fact]
    public void Test_2()
    {
        Assert.Equal<long>(PrimeFactors.For(2), new long[] { 2 });
    }

    [Fact]
    public void Test_3()
    {
        Assert.Equal<long>(PrimeFactors.For(3), new long[] { 3 });
    }

    [Fact]
    public void Test_4()
    {
        Assert.Equal<long>(PrimeFactors.For(4), new long[] { 2, 2 });
    }

    [Fact]
    public void Test_6()
    {
        Assert.Equal<long>(PrimeFactors.For(6), new long[] { 2, 3 });
    }

    [Fact]
    public void Test_8()
    {
        Assert.Equal<long>(PrimeFactors.For(8), new long[] { 2, 2, 2 });
    }

    [Fact]
    public void Test_9()
    {
        Assert.Equal<long>(PrimeFactors.For(9), new long[] { 3, 3 });
    }

    [Fact]
    public void Test_27()
    {
        Assert.Equal<long>(PrimeFactors.For(27), new long[] { 3, 3, 3 });
    }

    [Fact]
    public void Test_625()
    {
        Assert.Equal<long>(PrimeFactors.For(625), new long[] { 5, 5, 5, 5 });
    }

    [Fact]
    public void Test_901255()
    {
        Assert.Equal<long>(PrimeFactors.For(901255), new long[] { 5, 17, 23, 461 });
    }

    [Fact]
    public void Test_93819012551()
    {
        Assert.Equal<long>(PrimeFactors.For(93819012551), new long[] { 11, 9539, 894119 });
    }
}