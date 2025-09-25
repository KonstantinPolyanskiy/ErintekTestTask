namespace AgeComparatorConsole.Exceptions;

/// <summary>
/// Исключение, которые выбрасывается, в случае,
/// если возраст для сравнения оказался вне допустимого диапазона
/// </summary>
public sealed class InvalidAgeCompareRangeException : Exception
{
    /// <summary>
    /// Исключение без текста ошибки.
    /// </summary>
    public InvalidAgeCompareRangeException() : base() { }

    /// <summary>
    /// Исключение с текстом ошибки.
    /// </summary>
    /// <param name="message">Сообщение с доп. информацией.</param>
    public InvalidAgeCompareRangeException(string message) : base(message) { }
}