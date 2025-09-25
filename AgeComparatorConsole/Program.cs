using AgeComparator.Impl;
using AgeComparatorConsole.Comparers;
using AgeComparatorConsole.Exceptions;

namespace AgeComparatorConsole;

internal static class Program
{
    private static void Main(string[] args)
    {
        var comparer = new ExampleIntAgeComparer(0, 120);
        var comparator = new IntAgeComparator(comparer);

        while (true)
        {
            var ageInputs = new int[3];

            for (var i = 0; i < ageInputs.Length; i++)
            {
                var name = (Names)i;

                Console.Write($"Введите возраст для {name}: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out ageInputs[i]))
                {
                    Console.WriteLine("Неправильный ввод данных.");
                    break;
                }
            }

            try
            {
                var result = comparator.Compare(ageInputs[0], ageInputs[1], ageInputs[2]);

                Console.WriteLine($"Minimal age = {result.Minimal}");
                Console.WriteLine($"Middle age = {result.Middle}");
                Console.WriteLine($"Maximal age = {result.Maximal}");

            }
            catch (InvalidAgeCompareRangeException compareEx)
            {
                Console.WriteLine($"Возникла ошибка во время сортировки возраста: {compareEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла непредвиденная ошибка: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Enum с именами людей из ТЗ.
    /// </summary>
    private enum Names
    {
        Vasya = 0,
        Katya = 1,
        Misha = 2,
    }
}