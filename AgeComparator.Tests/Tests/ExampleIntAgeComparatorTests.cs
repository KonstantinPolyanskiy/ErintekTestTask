using AgeComparator.Impl;
using AgeComparator.Models;
using AgeComparatorConsole.Comparers;
using AgeComparatorConsole.Exceptions;
using FluentAssertions;

namespace AgeComparator.Tests.Tests;

public class ExampleIntAgeComparatorTests
{
    [Theory]
    [InlineData(60, 35, 15, 15, 35, 60)]
    [InlineData(45, 17, 17, 17, 17, 45)]
    [InlineData(55, 55, 55, 55, 55, 55)]
    [InlineData(0, 120, 60, 0, 60, 120)]
    [InlineData(120, 0, 60, 0, 60, 120)]
    public void Compare_Valid_ReturnsExpected(
        int vasya, int katya, int misha,
        int min, int mid, int max)
    {
        var comparer = new IntAgeComparator(new ExampleIntAgeComparer(0, 120));

        var result = comparer.Compare(vasya, katya, misha);

        result.Should().Be(new AgeComparingResult<int>(min, mid, max));
    }

    [Theory]
    [InlineData(-1, 10, 20)]   
    [InlineData(10, -1, 20)]
    [InlineData(10, 20, -1)]
    [InlineData(121, 10, 20)] 
    [InlineData(10, 121, 20)]
    [InlineData(10, 20, 121)]
    public void Compare_Invalid_Throws(int vasya, int katya, int misha)
    {
        var comparer = new IntAgeComparator(new ExampleIntAgeComparer());

        Action act = () => comparer.Compare(vasya, katya, misha);

        act.Should().Throw<InvalidAgeCompareRangeException>();
    }
}
