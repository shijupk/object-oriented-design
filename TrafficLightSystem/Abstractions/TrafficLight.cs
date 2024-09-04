namespace TrafficLightSystem.Abstractions;

public class TrafficLight
{
    private ITrafficLightState _currentState;

    public TrafficLight(ITrafficLightState initialState)
    {
        _currentState = initialState;
    }

    public void SetState(ITrafficLightState state)
    {
        _currentState = state;
    }

    public void Change()
    {
        _currentState.Handle(this);
    }

    public string GetCurrentState()
    {
        return _currentState.GetStateName();
    }
}