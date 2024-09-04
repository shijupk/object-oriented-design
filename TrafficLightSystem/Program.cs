using TrafficLightSystem.Abstractions;
using TrafficLightSystem.Features;

namespace TrafficLightSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize traffic light with Red light as the initial state
        var trafficLight = new TrafficLight(new RedLightState());

        // Create traffic controller with a time interval of 5 seconds
        ITrafficController trafficController = new TrafficController(trafficLight, 5000);

        // Start traffic control
        trafficController.Start();

        // For demo purposes, we stop the traffic control after 20 seconds
        Thread.Sleep(20000);
        trafficController.Stop();
    }
}