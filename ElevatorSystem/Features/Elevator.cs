using ElevatorSystem.Abstractions;

namespace ElevatorSystem.Features;

public class Elevator : IElevatorOperation
{
    private readonly Queue<Request> _requestQueue = new();
    private int _currentFloor = 0; // Assuming groundfloor is 0
    private ElevatorStatus _status = ElevatorStatus.Idle;

    public int GetCurrentFloor()
    {
        return _currentFloor;
    }

    public void MoveUp()
    {
        _status = ElevatorStatus.MovingUp;
        _currentFloor++;
        Console.WriteLine($"Elevator moving up to floor {_currentFloor}");
    }

    public void MoveDown()
    {
        _status = ElevatorStatus.MovingDown;
        _currentFloor--;
        Console.WriteLine($"Elevator moving down to floor {_currentFloor}");
    }

    public void OpenDoor()
    {
        _status = ElevatorStatus.DoorOpen;
        Console.WriteLine("Elevator door opened.");
    }

    public void CloseDoor()
    {
        _status = ElevatorStatus.DoorClosed;
        Console.WriteLine("Elevator door closed.");
    }

    public void ProcessRequest(Request request)
    {
        _requestQueue.Enqueue(request);
        ProcessNextRequest();
    }

    private void ProcessNextRequest()
    {
        if (_requestQueue.Count == 0)
        {
            _status = ElevatorStatus.Idle;
            return;
        }

        var request = _requestQueue.Dequeue();
        if (request.DestinationFloor > _currentFloor)
        {
            MoveUp();
        }
        else if (request.DestinationFloor < _currentFloor)
        {
            MoveDown();
        }

        OpenDoor();
        CloseDoor();

        // Recursively process the next request
        ProcessNextRequest();
    }
}