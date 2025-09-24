using FluentAssertions;
using GeometryCalculator.Calculators;
using GeometryCalculator.Tests.Consts;

namespace GeometryCalculator.Tests.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(15, 706.8583470577034)] // π * 15^2
    [InlineData(5,  78.539816)]         // округлённое значение из таблицы
    public void CircleArea_ShouldMatchTable(double r, double expected)
    {
        var area = BaseGeometryCalculator.CircleArea(r);
        
        area.Should().BeApproximately(expected, Eps.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    public void CircleArea_InvalidInput_ShouldThrow(double r)
    {
        Action act = () => BaseGeometryCalculator.CircleArea(r);
        
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}