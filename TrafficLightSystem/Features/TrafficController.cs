using TrafficLightSystem.Abstractions;

namespace TrafficLightSystem.Features;

public class TrafficController : ITrafficController
{
    private readonly int _interval;
    private readonly TrafficLight _trafficLight;
    private bool _isRunning;

    public TrafficController(TrafficLight trafficLight, int interval)
    {
        _trafficLight = trafficLight;
        _interval = interval;
    }

    public void Start()
    {
        _isRunning = true;
        while (_isRunning)
        {
            _trafficLight.Change();
            Console.WriteLine($"Current Traffic Light State: {_trafficLight.GetCurrentState()}");
            Thread.Sleep(_interval); // Simulate time delay between light changes
        }
    }

    public void Stop()
    {
        _isRunning = false;
    }
}