using AgeComparatorConsole.Exceptions;

namespace AgeComparatorConsole.Comparers;

/// <summary>
/// Реализация <see cref="IComparer{T}"/> для демонстрации гибкости решения.
/// В данном случае сравнение происходит с валидацией возраста.
/// В случае выхода из допустимого диапазона кидается <see cref="InvalidAgeCompareRangeException"/>
/// По умолчанию минимально возможный возраст - 0, а максимальный - 120.
/// </summary>
public sealed class ExampleIntAgeComparer() : IComparer<int>
{
    /// <summary>
    /// Минимально допустимый возраст.
    /// </summary>
    private int  _minimalPossibleAge = 0;
    
    /// <summary>
    /// Максимально допустимый возраст.
    /// </summary>
    private int _maximalPossibleAge = 120;

    /// <summary>
    /// Конструктор с указанием максимально допустимых возрастов.
    /// </summary>
    /// <param name="minimalPossibleAge"><see cref="_minimalPossibleAge"/></param>
    /// <param name="maximalPossibleAge"><see cref="_maximalPossibleAge"/></param>
    public ExampleIntAgeComparer(int minimalPossibleAge, int maximalPossibleAge) : this()
    {
        _minimalPossibleAge = minimalPossibleAge;
        _maximalPossibleAge = maximalPossibleAge;
    }

    public int Compare(int x, int y)
    {
        ValidateAge(x);
        ValidateAge(y);

        return x.CompareTo(y);
    }

    /// <summary>
    /// Проверка, что возраст находится в допустимых пределах.
    /// </summary>
    /// <param name="age">Проверяемый возраст.</param>
    private void ValidateAge(int age)
    {
        if (age < _minimalPossibleAge || age > _maximalPossibleAge)
        {
            throw new InvalidAgeCompareRangeException($"Возраст должен быть в диапазоне от {_minimalPossibleAge} до {_maximalPossibleAge} лет.");
        }
    }
}