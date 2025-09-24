using FluentAssertions;
using GeometryCalculator.Calculators;
using GeometryCalculator.Tests.Consts;

namespace GeometryCalculator.Tests.Tests;

public class TriangleTests
{
    [Theory]
    [InlineData(5, 5, 5, 10.825317547305483)] 
    [InlineData(6, 7, 12, 14.947826)]         
    public void TriangleArea_ShouldMatchTable(double a, double b, double c, double expected)
    {
        var area = BaseGeometryCalculator.TriangleArea(a, b, c);
        area.Should().BeApproximately(expected, Eps.Value);
    }

    [Theory]
    [InlineData(-1, 2, 3)]
    [InlineData(1, 0, 3)]
    [InlineData(1, 2, -3)]
    [InlineData(1, 2, 10)] 
    public void TriangleArea_Invalid_ShouldThrow(double a, double b, double c)
    {
        Action act = () => BaseGeometryCalculator.TriangleArea(a, b, c);
        act.Should().Throw<Exception>(); 
    }

    [Theory]
    [InlineData(-1, 2, 3)]
    [InlineData(1, 0, 3)]
    [InlineData(1, 2, -3)]
    [InlineData(1, 2, 10)] 
    public void TriangleDoesNotValid(double a, double b, double c)
    {
        var isTriangle = BaseGeometryCalculator.IsTriangle(a, b, c);
        isTriangle.Should().BeFalse();
    }
}