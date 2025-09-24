namespace Elevator.Contracts;

/// <summary>
/// Контракт лифта, поддерживающего синхронный вызов перемещения по этажам.
/// </summary>
public interface ISyncElevator
{
    /// <summary>
    /// Переместить этаж на уровень <see cref="floor"/>
    /// </summary>
    /// <param name="floor">Номер этажа.</param>
    /// <returns>Этаж после перемещения.</returns>
    int Move(int floor);
}