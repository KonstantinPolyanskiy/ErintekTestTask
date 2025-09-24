using FluentAssertions;
using GeometryCalculator.Calculators;
using GeometryCalculator.Tests.Consts;

namespace GeometryCalculator.Tests.Tests;

public class SphereTests
{
    [Theory]
    [InlineData(5, 523.5987755982989)]
    [InlineData(1, 4.1887902048)] 
    public void SphereVolume_ShouldMatchTable(double r, double expected)
    {
        var v = BaseGeometryCalculator.SphereVolume(r);
        v.Should().BeApproximately(expected, Eps.Value);
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(double.NaN)]
    [InlineData(double.NegativeInfinity)]
    public void SphereVolume_InvalidInput_ShouldThrow(double r)
    {
        Action act = () => BaseGeometryCalculator.SphereVolume(r);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}