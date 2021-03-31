using System.Collections.Generic;
using System.Linq;

public class SumOfMultiples
{
    private readonly IEnumerable<int> _baseMultiples;

    /// <summary>
    /// Configures the class with the base multiples 3 and 5.
    /// </summary>
    public SumOfMultiples() : this(new[] {3, 5}) { }

    /// <summary>
    /// Configures the class with a set of base multiples.
    /// </summary>
    public SumOfMultiples(IEnumerable<int> baseMultiples)
    {
        _baseMultiples = baseMultiples;
    }

    /// <summary>
    /// Sums all multiples up to but not including the given value
    /// </summary>
    /// <param name="to">The exclusive upper value</param>
    /// <returns>The sum of the multiples</returns>
    public int To(int to)
    {
        return Enumerable.Range(1, to - 1).Where(IsMultiple).Sum();
    }

    private bool IsMultiple(int value)
    {
        return _baseMultiples.Any(baseMultiple => value % baseMultiple == 0);
    }
}
