using AgeComparator.Models;

namespace AgeComparator.Abstractions;

/// <summary>
/// Базовый класс для сортировки трех возрастов.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TResult"></typeparam>
public abstract class BaseAgeComparator<T, TResult>
{
    /// <summary>
    /// Объект, с помощью которого будет происходить сравнение.
    /// </summary>
    protected readonly IComparer<T> Comparer;

    /// <summary>
    /// Базовый конструктор компаратора возраста
    /// </summary>
    /// <param name="comparer"><see cref="Comparer"/></param>
    protected BaseAgeComparator(IComparer<T> comparer)
    {
        Comparer = comparer;
    }
    
    /// <summary>
    /// Производит сортировку и возврат результата типа <see cref="AgeComparingResult{T}"/>.
    /// </summary>
    /// <param name="a">Первое значение возраста.</param>
    /// <param name="b">Второе значение возраста.</param>
    /// <param name="c">Третье значение возраста.</param>
    /// <returns></returns>
    public abstract TResult Compare(T a, T b, T c);

    /// <summary>
    /// Сортировка трех переданных значений по возрастанию.
    /// </summary>
    /// <param name="a">Аргумент 1.</param>
    /// <param name="b">Аргумент 2.</param>
    /// <param name="c">Аргумент 3.</param>
    /// <returns> Отсортированный кортеж аргументов a, b, c.</returns>
    protected (T min, T mid, T max) SortAscending(T a, T b, T c)
    {
        var min = a;
        var mid = b;
        var max = c;

        if (Comparer.Compare(min, mid) > 0)
        {
            (min, mid) = (mid, min);
        }

        if (Comparer.Compare(mid, max) > 0)
        {
            (mid, max) = (max, mid);
        }

        if (Comparer.Compare(min, mid) > 0)
        {
            (min, mid) = (mid, min);
        }

        return (min, mid, max);
    }
}