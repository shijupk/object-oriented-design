using ElevatorSystem.Abstractions;
using ElevatorSystem.Features;

namespace ElevatorSystem;

public class Program
{
    public static void Main(string[] args)
    {
        IElevatorOperation elevator1 = new Elevator();
        IElevatorOperation elevator2 = new Elevator();

        var elevators = new List<IElevatorOperation> { elevator1, elevator2 };
        var controller = new ElevatorController(elevators);

        var floor0 = new Floor(0, controller);
        var floor1 = new Floor(1, controller);
        var floor2 = new Floor(2, controller);

        // Simulate requests
        floor0.RequestElevator(2, Direction.Up);
        floor1.RequestElevator(0, Direction.Down);
    }
}