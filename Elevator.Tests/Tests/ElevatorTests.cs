namespace Elevator.Tests.Tests;

public class ElevatorTests
{
    [Fact]
    public void Move_Sync_ReturnsFinalFloor_Correctly()
    {
        var elevator = new Impl.Elevator(10, -3);

        var floorAfterMove = elevator.Move(5); // двигаемся с первого на пятый этаж
        Assert.Equal(5, floorAfterMove);

        elevator.Move(10); // двигаемся с пятого на десятый этаж;

        Assert.Equal(10, elevator.CurrentFloor()); 
    }

    [Fact]
    public void Move_Sync_OutOfRange_NoMove()
    {
        var elevator = new Impl.Elevator(10, -3);

        var floorAfterMove = elevator.Move(1); // с первого на первый этаж - не двигаемся
        var floorAfterMoveOutOfRange = elevator.Move(100); // с первого на недопустимый сотый - не двигаемся

        Assert.Equal(1, floorAfterMove);
        Assert.Equal(1, floorAfterMoveOutOfRange);
    }

    [Fact]
    public async Task Move_Async_ReturnsFinalFloor_Correctly()
    {
        var elevator = new Impl.Elevator(26, -3);

        var start = new ManualResetEventSlim(false);

        // одновременно стартуем работу с лифтом
        Task<int> Run(int target) => Task.Run(async () =>
        {
            start.Wait();                    
            return await elevator.MoveAsync(target, CancellationToken.None);
        });

        var t1 = Run(10);
        var t2 = Run(-2);
        var t3 = Run(26);

        start.Set();

        var tasks = new List<Task<int>> { t1, t2, t3 };
        var completionOrder = new List<int>(3);
        while (tasks.Count > 0)
        {
            var done = await Task.WhenAny(tasks);
            completionOrder.Add(done.Result);
            tasks.Remove(done);
        }

        // в списке посещенных этажей должны быть все
        Assert.Contains(10, completionOrder);
        Assert.Contains(-2, completionOrder);
        Assert.Contains(26, completionOrder);

        // последний этаж, на котором находится лифт должен быть равен этажу, на который едем в результате последней операции
        var lastResult = completionOrder.Last();
        Assert.Equal(lastResult, elevator.Move(lastResult));
    }
}