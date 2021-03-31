using System;
using System.Linq;

public class Triangle
{
    private readonly decimal[] _sides;

    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class.
    /// </summary>
    /// <param name="a">The first side</param>
    /// <param name="b">The second side</param>
    /// <param name="c">The third side</param>
    /// <exception cref="TriangleException">Thrown if this is not a valid triangle</exception>
    public Triangle(decimal a, decimal b, decimal c)
    {
        if(!Valid(a, b, c)) throw new TriangleException();
        _sides = new[] { a, b, c };
    }

    /// <summary>
    /// Gets what kind of triangle this is
    /// </summary>
    public TriangleKind Kind()
    {
        return (TriangleKind)DistinctSides();
    }

    private static bool Valid(decimal a, decimal b, decimal c)
    {
        return a + b > c && b + c > a && a + c > b;
    }

    private int DistinctSides()
    {
        return _sides.Distinct().Count();
    }
}

/// <summary>
/// Thrown for invalid triangles
/// </summary>
public class TriangleException : Exception
{
    public TriangleException() : base("Invalid triangle") { }
}

public enum TriangleKind
{
    Equilateral = 1,
    Isosceles = 2,
    Scalene = 3
}