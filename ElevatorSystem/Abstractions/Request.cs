namespace ElevatorSystem.Abstractions;

public enum Direction
{
    Up,
    Down,
    Idle
}

public enum ElevatorStatus
{
    MovingUp,
    MovingDown,
    Idle,
    DoorOpen,
    DoorClosed
}

public class Request(int destinationFloor, Direction direction)
{
    public int DestinationFloor { get; } = destinationFloor;
    public Direction Direction { get; } = direction;
}