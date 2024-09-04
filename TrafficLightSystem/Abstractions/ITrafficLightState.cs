namespace TrafficLightSystem.Abstractions;

public interface ITrafficLightState
{
    void Handle(TrafficLight trafficLight);
    string GetStateName();
}

public interface ITrafficController
{
    void Start();
    void Stop();
}