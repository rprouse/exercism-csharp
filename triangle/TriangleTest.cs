using System;
using Xunit;


public class TriangleTest
{
    [Fact]
    public void Equilateral_triangles_have_equal_sides()
    {
        Assert.Equal(TriangleKind.Equilateral, new Triangle(2, 2, 2).Kind());
    }

    [Fact]
    public void Larger_equilateral_triangles_also_have_equal_sides()
    {
        Assert.Equal(TriangleKind.Equilateral, new Triangle(10, 10, 10).Kind());
    }

    [Fact]
    public void Isosceles_triangles_have_last_two_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, new Triangle(3, 4, 4).Kind());
    }

    [Fact]
    public void Isosceles_triangles_have_first_and_last_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, new Triangle(4, 3, 4).Kind());
    }

    [Fact]
    public void Isosceles_triangles_have_two_first_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, new Triangle(4, 4, 3).Kind());
    }

    [Fact]
    public void Isosceles_triangles_have_in_fact_exactly_two_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, new Triangle(10, 10, 2).Kind());
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides()
    {
        Assert.Equal(TriangleKind.Scalene, new Triangle(3, 4, 5).Kind());
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides_at_a_larger_scale_too()
    {
        Assert.Equal(TriangleKind.Scalene, new Triangle(10, 11, 12).Kind());
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides_in_descending_order_either()
    {
        Assert.Equal(TriangleKind.Scalene, new Triangle(5, 4, 2).Kind());
    }

    [Fact]
    public void Very_small_triangles_are_legal()
    {
        Assert.Equal(TriangleKind.Scalene, new Triangle(0.4m, 0.6m, 0.3m).Kind());
    }

    [Fact]
    public void Triangles_with_no_size_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(0, 0, 0).Kind());
    }

    [Fact]
    public void Triangles_with_negative_sides_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(3, 4, -5).Kind());
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(1, 1, 3).Kind());
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal_2()
    {
        Assert.Throws<TriangleException>(() => new Triangle(2, 4, 2).Kind());
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal_3()
    {
        Assert.Throws<TriangleException>(() => new Triangle(7, 3, 2).Kind());
    }
}