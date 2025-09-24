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
     Task MoveAsync(int floor, CancellationToken ct);
}