using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;


public class StrainTest
{
    [Fact]
    public void Empty_keep()
    {
        Assert.Equal(new LinkedList<int>().Keep(x => x < 10), new LinkedList<int>());
    }

    [Fact]
    public void Keep_everything()
    {
        Assert.Equal(new HashSet<int> { 1, 2, 3 }.Keep(x => x < 10), new HashSet<int> { 1, 2, 3 });
    }

    [Fact]
    public void Keep_first_and_last()
    {
        Assert.Equal(new[] { 1, 2, 3 }.Keep(x => x % 2 != 0), new[] { 1, 3 });
    }

    [Fact]
    public void Keep_neither_first_nor_last()
    {
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }.Keep(x => x % 2 == 0), new List<int> { 2, 4 });
    }

    [Fact]
    public void Keep_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.Equal(words.Keep(x => x.StartsWith("z")), "zebra zombies zelot".Split(' '));
    }

    [Fact]
    public void Keep_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 5, 5, 5 }, new[] { 5, 1, 2 }, new[] { 1, 5, 2 }, new[] { 1, 2, 5 } };
        Assert.Equal(actual.Keep(x => x.Contains(5)), expected);
    }

    [Fact]
    public void Empty_discard()
    {
        Assert.Equal(new LinkedList<int>().Discard(x => x < 10), new LinkedList<int>());
    }

    [Fact]
    public void Discard_nothing()
    {
        Assert.Equal(new HashSet<int> { 1, 2, 3 }.Discard(x => x > 10), new HashSet<int> { 1, 2, 3 });
    }

    [Fact]
    public void Discard_first_and_last()
    {
        Assert.Equal(new[] { 1, 2, 3 }.Discard(x => x % 2 != 0), new[] { 2 });
    }

    [Fact]
    public void Discard_neither_first_nor_last()
    {
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }.Discard(x => x % 2 == 0), new List<int> { 1, 3, 5 });
    }

    [Fact]
    public void Discard_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.Equal(words.Discard(x => x.StartsWith("z")), "apple banana cherimoya".Split(' '));
    }

    [Fact]
    public void Discard_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 1, 2, 3 }, new[] { 2, 1, 2 }, new[] { 2, 2, 1 } };
        Assert.Equal(actual.Discard(x => x.Contains(5)), expected);
    }
}