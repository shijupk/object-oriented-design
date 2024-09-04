# Traffic Light System

Designing a traffic light system in C# following SOLID principles involves creating classes and interfaces that encapsulate the core functionalities of traffic lights, such as managing states (Red, Yellow, Green), handling transitions, and controlling multiple intersections. Below is a high-level design followed by a complete example implementation.

## High-Level Design

### 1. Single Responsibility Principle (SRP)

- **TrafficLight:** Manages the state of a single traffic light.
- **TrafficLightState:** Represents a state (Red, Yellow, Green) of a traffic light.
- **TrafficController:** Manages the overall traffic light control for an intersection.

### 2. Open/Closed Principle (OCP)

The system should allow adding new states or light behaviors without modifying existing classes.

### 3. Liskov Substitution Principle (LSP)

Derived classes like RedLightState, GreenLightState, or YellowLightState should be able to replace the base TrafficLightState class without altering the correctness of the program.
Interface Segregation Principle (ISP)

Define small, focused interfaces like ITrafficLightState and ITrafficController so that classes only need to implement the methods they actually use.

### 4. Dependency Inversion Principle (DIP)

High-level modules like TrafficController should depend on abstractions (interfaces) rather than concrete implementations.

## Key Points

- **TrafficLight:** Manages the current state of the traffic light.
- **TrafficLightState:** Represents and handles the behavior of different traffic light states (Red, Yellow, Green).
- **TrafficController:** Controls the traffic light, handling the transitions between states and the overall timing logic.
- **Interfaces:** Small and focused interfaces (ITrafficLightState and ITrafficController) allow for flexible and maintainable code.

**SOLID Principles:** The design follows SOLID principles, making it easy to extend, modify, and test the system.
This design ensures that the traffic light system is modular, maintainable, and scalable. It allows for easy addition of new states (e.g., blinking lights for pedestrian crossings) without modifying existing code, adhering to the Open/Closed Principle. The use of state patterns helps manage the transitions cleanly, ensuring that the Single Responsibility Principle is respected.
