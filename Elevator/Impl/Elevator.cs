using Elevator.Contracts;

namespace Elevator.Impl;

/// <summary>
/// Лифт.
/// </summary>
public sealed class Elevator : IParallelElevator, ISyncElevator
{
    #region Fields

    /// <summary>
    /// Минимальный этаж, на который способен опуститься лифт.
    /// </summary>
    private readonly int _minFloor;

    /// <summary>
    /// Максимальный этаж, на который способен подняться лифт.
    /// </summary>
    private readonly int _maxFloor;

    /// <summary>
    /// Текущий этаж, на котором находится лифт.
    /// </summary>
    private int _currentFloor;

    /// <summary>
    /// Семафор для постановки в очередь нескольких параллельных запросов на передвижение лифта.
    /// </summary>
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    /// <summary>
    /// Способ вывода информации о перемещениях лифта. (В данном случае - в консоль) 
    /// </summary>
    private Action<string> _write = Console.WriteLine;

    #endregion

    #region Ctor

    /// <summary>
    /// Создать лифт.
    /// </summary>
    /// <param name="maxFloor">Максимально допустимый этаж, на который способен переместиться лифт.</param>
    /// <param name="minFloor">Минимально допустимый этаж, на который способен переместиться лифт.</param>
    /// <exception cref="ArgumentException">В случае, если максимальная высота меньше, чем минимальная.</exception>
    public Elevator(int maxFloor, int minFloor)
    {
        if (maxFloor < minFloor)
        {
            throw new ArgumentException("Максимальная высота подъема не может превышать минимальную высоту подъема.");
        }

        _minFloor = minFloor;
        _maxFloor = maxFloor;
        
        _currentFloor = Math.Clamp(1, _minFloor, _maxFloor);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Этаж, на котором находится лифт.
    /// </summary>
    public int CurrentFloor() => _currentFloor;

    /// <inheritdoc />
    public async Task<int> MoveAsync(int floor, CancellationToken ct)
    {
        // Ставим параллельные запросы в очередь
        await _semaphore.WaitAsync(ct).ConfigureAwait(false);

        try
        {
            if (floor < _minFloor || floor > _maxFloor)
            {
                _write($"Этаж {floor} вне промежутка между {_minFloor} и {_maxFloor}");
                return _currentFloor;
            }

            if (floor == _currentFloor)
            {
                _write($"Лифт уже находится на этаже {_currentFloor}");
                return _currentFloor;
            }

            while (_currentFloor < floor)
            {
                MoveUp(_write);
            }

            while (_currentFloor > floor)
            {
                MoveDown(_write);
            }
        }
        finally
        {
            _semaphore.Release();
        }

        return _currentFloor;
    }

    /// <inheritdoc />
    public int Move(int floor)
    {
        // Для синхронного вызова блокируем поток
        return MoveAsync(floor, CancellationToken.None).GetAwaiter().GetResult();
    }

    #endregion

    #region PrivateMethods

    /// <summary>
    /// Переместить этаж на один вверх.
    /// </summary>
    /// <param name="write">Способ вывода информации</param>
    private void MoveUp(Action<string> write)
    {
        if (_currentFloor >= _maxFloor)
        {
            write($"Лифт на максимальном этаже: {_maxFloor}.");
            
            return;
        }

        _currentFloor++;

        write($"Текущий этаж: {_currentFloor}.");
    }

    /// <summary>
    /// Переместить этаж на один вниз.
    /// </summary>
    /// <param name="write">Способ вывода информации</param>
    private void MoveDown(Action<string> write)
    {
        if (_currentFloor <= _minFloor)
        {
            write($"Лифт на минимальном этаже: {_minFloor}.");

            return;
        }

        _currentFloor--;

        write($"Текущий этаж: {_currentFloor}.");
    }

    #endregion
}