using ElevatorSystem.Abstractions;

namespace ElevatorSystem.Features;

public class ElevatorController : IRequestProcessor
{
    private readonly List<IElevatorOperation> _elevators;

    public ElevatorController(List<IElevatorOperation> elevators)
    {
        _elevators = elevators;
    }

    public void AddRequest(Request request)
    {
        var elevator = FindBestElevator(request);
        elevator?.ProcessRequest(request);
    }

    private IElevatorOperation FindBestElevator(Request request)
    {
        // Simple logic to find the nearest idle elevator
        // This can be extended with more sophisticated algorithms
        IElevatorOperation bestElevator = null;
        var minDistance = int.MaxValue;

        foreach (var elevator in _elevators)
        {
            var distance = Math.Abs(elevator.GetCurrentFloor() - request.DestinationFloor);
            if (distance < minDistance)
            {
                minDistance = distance;
                bestElevator = elevator;
            }
        }

        return bestElevator;
    }
}