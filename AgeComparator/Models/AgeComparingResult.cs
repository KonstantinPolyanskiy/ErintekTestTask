namespace AgeComparator.Models;

/// <summary>
/// Результат сравнения трех значений произвольного типа <see cref="T"/>, описывающих данные, на основе которых можно рассчитать возраст
/// </summary>
/// <param name="Minimal">Минимальный возраст.</param>
/// <param name="Middle">Средний возраст.</param>
/// <param name="Maximal">Максимальный возраст.</param>
/// <typeparam name="T">Тип, описывающий возраст.</typeparam>
public readonly record struct AgeComparingResult<T>(T Minimal, T Middle, T Maximal);

