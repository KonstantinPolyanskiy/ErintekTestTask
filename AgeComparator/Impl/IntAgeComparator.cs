using AgeComparator.Abstractions;
using AgeComparator.Models;

namespace AgeComparator.Impl;

/// <summary>
/// Реализация "сравнивателя" возраста, основанная на типе <see cref="int"/> (кол-во лет).
/// </summary>
/// <param name="comparer">Объект, с помощью которого будет происходить сравнение.</param>
public sealed class IntAgeComparator(IComparer<int> comparer) : BaseAgeComparator<int, AgeComparingResult<int>>(comparer)
{
    public IntAgeComparator() : this(Comparer<int>.Default) { }

    /// <inheritdoc />
    public override AgeComparingResult<int> Compare(int a, int b, int c)
    {
        var (min, mid, max) = SortAscending(a, b, c);

        return new AgeComparingResult<int>(min, mid, max);
    }
}