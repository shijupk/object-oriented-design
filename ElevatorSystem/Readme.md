# Elevator System

Designing an elevator system that adheres to SOLID principles in C# involves creating classes and interfaces that represent different components of the elevator system, each with a single responsibility. The design should be flexible, maintainable, and easy to extend. Below is a high-level approach followed by an example implementation.

## High-Level Design

### Single Responsibility Principle (SRP)

**Elevator:** Manages the state and operation of a single elevator.
**Floor:** Represents a floor in the building and manages requests for the elevator.
**ElevatorController:** Manages multiple elevators and directs them based on requests.
**Request:** Represents a request to move to a particular floor, either from inside the elevator or from a floor.

### Open/Closed Principle (OCP)

The system should allow adding new types of elevators or floors without modifying existing classes.
For instance, you might have a BasicElevator and later extend it with a FreightElevator for different behaviors.

### Liskov Substitution Principle (LSP)

Derived classes like FreightElevator should be able to replace the base Elevator class without altering the correctness of the program.
Interface Segregation Principle (ISP)

Define small, focused interfaces like IRequestProcessor, IElevatorOperation, and IFloorRequestHandler so that classes only need to implement the methods they actually use.
Dependency Inversion Principle (DIP)

High-level modules like ElevatorController should depend on abstractions (interfaces) rather than concrete implementations.

## Key Points:

Elevator manages the state and operation of the elevator.
Floor handles the user’s request for an elevator.
ElevatorController directs requests to the appropriate elevator.
Request represents a movement request.
Interfaces like IElevatorOperation, IRequestProcessor, and IFloorRequestHandler ensure that the system is extendable and adheres to the ISP and DIP principles.

This basic example can be extended to include more advanced features like prioritizing requests, handling multiple elevators more intelligently, or adding a user interface. The design ensures that each class has a clear responsibility and the system is easy to extend or modify.
