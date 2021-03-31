using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


public class AccumulateTest
{
    [Fact]
    public void Empty_accumulation_produces_empty_accumulation()
    {
        Assert.Equal(new int[0].Accumulate(x => x * x), new int[0]);
    }

    [Fact]
    public void Accumulate_squares()
    {
        Assert.Equal(new[] { 1, 2, 3 }.Accumulate(x => x * x), new[] { 1, 4, 9 });
    }

    [Fact]
    public void Accumulate_upcases()
    {
        Assert.Equal(new List<string> { "hello", "world" }.Accumulate(x => x.ToUpper()),
            new List<string> { "HELLO", "WORLD" });
    }

    [Fact]
    public void Accumulate_reversed_strings()
    {
        Assert.Equal("the quick brown fox etc".Split(' ').Accumulate(Reverse),
            "eht kciuq nworb xof cte".Split(' '));
    }

    private static string Reverse(string value)
    {
        var array = value.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    [Fact]
    public void Accumulate_within_accumulate()
    {
        var actual = new[] { "a", "b", "c" }.Accumulate(c =>
            string.Join(" ", new[] { "1", "2", "3" }.Accumulate(d => c + d)));
        Assert.Equal(actual, new[] { "a1 a2 a3", "b1 b2 b3", "c1 c2 c3" });
    }

    [Fact]
    public void Accumulate_is_lazy()
    {
        var counter = 0;
        var accumulation = new[] { 1, 2, 3 }.Accumulate(x => x * counter++);

        Assert.Equal(0, counter);
        accumulation.ToList();
        Assert.Equal(3, counter);
    }
}