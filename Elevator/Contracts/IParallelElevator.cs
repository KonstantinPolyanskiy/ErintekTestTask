namespace Elevator.Contracts;

/// <summary>
/// Контракт лифта, поддерживающего параллельный вызов перемещения по этажам.
/// </summary>
public interface IParallelElevator
{
     /// <summary>
     /// Переместить этаж на уровень <see cref="floor"/>
     /// </summary>
     /// <param name="floor">Номер этажа.</param>
     /// <param name="ct">Токен отмены.</param>
     /// <returns>Этаж после перемещения.</returns>
     Task<int> MoveAsync(int floor, CancellationToken ct);
}