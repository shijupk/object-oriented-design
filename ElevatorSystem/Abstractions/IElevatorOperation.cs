namespace ElevatorSystem.Abstractions;

public interface IElevatorOperation
{
    void MoveUp();
    void MoveDown();
    void OpenDoor();
    void CloseDoor();
    int GetCurrentFloor();
    void ProcessRequest(Request request);
}

public interface IRequestProcessor
{
    void AddRequest(Request request);
}

public interface IFloorRequestHandler
{
    void RequestElevator(int floorNumber, Direction direction);
}