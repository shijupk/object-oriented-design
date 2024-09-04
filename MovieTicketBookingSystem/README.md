Designing a Movie Ticket Booking System that adheres to SOLID principles and incorporates design patterns involves creating a scalable, maintainable architecture that supports various functionalities such as movie management, showtimes, seat selection, bookings, and payments.

High-Level Design
Core Components
Movie: Manages the information related to movies.
Theater: Manages theaters and their associated screens.
Showtime: Manages the showtimes of movies in different theaters.
Seat: Manages seat availability and selection.
Booking: Manages the booking process for tickets.
Payment: Handles payment processing.
Applying SOLID Principles
Single Responsibility Principle (SRP):

Each class has a single responsibility. For example:
Movie manages movie details.
Showtime handles movie timings.
Booking manages the booking process.
Open/Closed Principle (OCP):

The system should be open for extension but closed for modification. For example:
Adding new payment methods (e.g., credit card, PayPal) should not require changing the existing payment processing logic.
Liskov Substitution Principle (LSP):

Subtypes should be substitutable for their base types. For example:
CreditCardPayment and PayPalPayment should be interchangeable as they derive from a common PaymentMethod base class.
Interface Segregation Principle (ISP):

Clients should not be forced to implement interfaces they don't use. For example:
Separate interfaces like IShowtimeService, ISeatSelectionService, and IPaymentService ensure that classes only implement what they need.
Dependency Inversion Principle (DIP):

High-level modules should depend on abstractions, not concrete implementations. For example:
The BookingService depends on IPaymentService, not on specific implementations like CreditCardPayment.
Design Patterns Used
Factory Pattern:

Used to create instances of complex objects like PaymentMethod, Seat, or Booking without specifying the exact class.
Example: A PaymentFactory can be used to create instances of different payment methods (CreditCard, PayPal).
Strategy Pattern:

Used to select an algorithm or strategy at runtime. For example:
Payment processing strategies (CreditCardPayment, PayPalPayment) can be selected based on user input.
Observer Pattern:

Used to notify various parts of the system about events like booking confirmation or seat availability changes.
Example: When a booking is confirmed, the BookingService can notify other components to update seat availability.
Decorator Pattern:

Used to add additional responsibilities to objects dynamically.
Example: Adding promotional discounts to bookings or applying loyalty points can be implemented using decorators around a Booking class.
Singleton Pattern:

Used to ensure that a class has only one instance and provide a global point of access to it.
Example: A TheaterCatalog or MovieCatalog class could be a singleton, ensuring that all components access the same catalog instance.

Key Points of the Design
Factory Pattern: Can be used to create instances of PaymentMethod based on user selection.
Strategy Pattern: Allows the PaymentService to process payments using different strategies (e.g., credit card, PayPal).
Observer Pattern: Could be extended to notify other services when a booking is confirmed or canceled.
Decorator Pattern: Could be used to add additional features like discounts or loyalty points to the Booking.
Singleton Pattern: The MovieService, ShowtimeService, or TheaterCatalog could be implemented as singletons to ensure that the same instance is used throughout the application.
This implementation adheres to the SOLID principles, ensuring that the system is scalable, maintainable, and flexible for future enhancements.