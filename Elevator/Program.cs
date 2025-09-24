
namespace Elevator;

internal static class Program
{
    private static void Main(string[] args)
    {
        var elevator = new Impl.Elevator(26, -3);

        while (true)
        {
            Console.Write("Введите номер этажа: ");

            var input = Console.ReadLine();
            if (input == null)
            {
                break;
            }

            if (!int.TryParse(input, out int floor))
            {
                Console.WriteLine("Ошибка ввода, необходимо целое число");
                continue;
            }

            elevator.Move(floor);
        }
    }
}


