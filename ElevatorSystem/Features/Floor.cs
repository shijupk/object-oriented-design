using ElevatorSystem.Abstractions;

namespace ElevatorSystem.Features;

public class Floor : IFloorRequestHandler
{
    private readonly IRequestProcessor _elevatorController;
    private readonly int _floorNumber;

    public Floor(int floorNumber, IRequestProcessor elevatorController)
    {
        _floorNumber = floorNumber;
        _elevatorController = elevatorController;
    }

    public void RequestElevator(int floorNumber, Direction direction)
    {
        var request = new Request(floorNumber, direction);
        _elevatorController.AddRequest(request);
    }
}