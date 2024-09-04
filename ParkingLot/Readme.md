# Parking Lot

Designing a parking lot system in C# following the SOLID principles involves creating classes and interfaces that encapsulate the core functionalities of a parking lot, such as vehicle management, parking spot allocation, and payment processing. Below is a high-level design followed by a complete example implementation.

## High-Level Design

### Single Responsibility Principle (SRP)

**Vehicle:** Represents a vehicle entering the parking lot.
**ParkingSpot:** Represents a parking spot in the parking lot.
**ParkingLot:** Manages the overall parking lot, including parking spots and vehicles.
**ParkingTicket:** Represents a ticket issued to a vehicle for parking.
**Payment:** Handles payment processing for parking.

### Open/Closed Principle (OCP)

The system should allow adding new types of vehicles, parking spots, or payment methods without modifying existing classes.

### Liskov Substitution Principle (LSP)

Derived classes like Motorcycle, Car, or Truck should be able to replace the base Vehicle class without altering the correctness of the program.
Interface Segregation Principle (ISP)

Define small, focused interfaces like IVehicle, IParkingSpot, and IPaymentProcessor so that classes only need to implement the methods they actually use.
Dependency Inversion Principle (DIP)

High-level modules like ParkingLot should depend on abstractions (interfaces) rather than concrete implementations.

## Key Points

**Vehicle:** Represents vehicles of different sizes.
**ParkingSpot:** Represents parking spots that can accommodate different vehicle sizes.
**ParkingTicket:** Issues and tracks tickets for vehicles parked in the lot.
**PaymentProcessor:** Handles payment calculation and processing.
**ParkingLot:** Manages parking spots, vehicles, and payments.

This design ensures that each class has a clear responsibility, adheres to the principles of modularity and extensibility, and makes it easy to add new features or extend the system. For example, you can add new types of parking spots or payment methods without altering existing code.