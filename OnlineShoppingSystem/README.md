# Online Shopping System

Problem Statement: Design an online shopping platform where users can browse products, add them to a cart, place orders, make payments, and track orders. The system should also handle inventory management and user accounts.
Key Concepts: Object modeling, encapsulation, SOLID principles, design patterns like MVC (Model-View-Controller), Factory, and Strategy.


Designing an Online Shopping System in C# while adhering to the SOLID principles involves creating a flexible, maintainable, and scalable architecture that encapsulates core functionalities like product management, user management, shopping carts, orders, and payments.

High-Level Design
Single Responsibility Principle (SRP)

Product: Manages the information related to products.
User: Manages user-related information and actions.
ShoppingCart: Handles the shopping cart operations for a user.
Order: Manages order creation, processing, and tracking.
Payment: Handles payment processing and related operations.
Open/Closed Principle (OCP)

The system should allow adding new types of payment methods, shipping options, or discount strategies without modifying existing classes.
Liskov Substitution Principle (LSP)

Derived classes like CreditCardPayment or PayPalPayment should be able to replace the base PaymentMethod class without altering the correctness of the program.
Interface Segregation Principle (ISP)

Define small, focused interfaces like IPaymentProcessor, IOrderService, and IProductCatalog so that classes only need to implement the methods they actually use.
Dependency Inversion Principle (DIP)

High-level modules like OrderService should depend on abstractions (interfaces) rather than concrete implementations.

Key Points:
Product: Represents a product in the online shopping system.
User: Represents a user in the system.
ShoppingCart

