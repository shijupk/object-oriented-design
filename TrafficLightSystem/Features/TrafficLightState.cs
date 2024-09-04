using TrafficLightSystem.Abstractions;

namespace TrafficLightSystem.Features;

public abstract class TrafficLightState : ITrafficLightState
{
    public abstract void Handle(TrafficLight trafficLight);
    public abstract string GetStateName();
}

public class RedLightState : TrafficLightState
{
    public override void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Red Light - Stop");
        // Transition to next state
        trafficLight.SetState(new GreenLightState());
    }

    public override string GetStateName()
    {
        return "Red";
    }
}

public class GreenLightState : TrafficLightState
{
    public override void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Green Light - Go");
        // Transition to next state
        trafficLight.SetState(new YellowLightState());
    }

    public override string GetStateName()
    {
        return "Green";
    }
}

public class YellowLightState : TrafficLightState
{
    public override void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Yellow Light - Slow Down");
        // Transition to next state
        trafficLight.SetState(new RedLightState());
    }

    public override string GetStateName()
    {
        return "Yellow";
    }
}