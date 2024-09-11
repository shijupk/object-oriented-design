# In-Memory Database Design

To implement an in-memory relational database in C#, we can use a combination of data structures like dictionaries and lists to mimic tables, rows, and columns. This approach is purely in-memory and does not persist data, but it can be used to perform operations like inserting, selecting, updating, and deleting records. We will also simulate relationships between tables (like foreign keys) using these structures.

## Steps to implement an in-memory relational database:
-  Define a table structure.
- Allow insertion of records.
- Implement querying (simple SELECT statements).
- Support updates and deletes.
- Support simple relations (like foreign keys between tables).

## SOLID Principles:
- **Single Responsibility Principle (SRP):** Each class should have one responsibility.
- **Open/Closed Principle (OCP):** Classes should be open for extension but closed for modification.
- **Liskov Substitution Principle (LSP):** Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.
- **Interface Segregation Principle (ISP):** Clients should not be forced to depend on interfaces they do not use.
- **Dependency Inversion Principle (DIP):** High-level modules should not depend on low-level modules; both should depend on abstractions.

## Design Patterns:
- **Factory Pattern:** To create tables dynamically, following the Open/Closed Principle.
- **Repository Pattern:** For data access, keeping the logic abstracted and easily modifiable.
- **Strategy Pattern:** For handling different query strategies, making the query behavior extensible.

## Explanation of Design Choices:
- **Single Responsibility Principle (SRP):** Each class has a single responsibility. The Table class manages rows, while the InMemoryDatabase class manages tables. The TableFactory handles the creation of tables.
- **Open/Closed Principle (OCP):** The TableFactory allows new types of tables to be created without modifying the factory itself. The query strategies can be extended using the Strategy Pattern without modifying the core logic.
- **Liskov Substitution Principle (LSP):** Interfaces (IDatabase, ITable) ensure that any class implementing these interfaces can be used interchangeably.
- **Interface Segregation Principle (ISP):** We define small, focused interfaces (IDatabase, ITable, IQueryStrategy) to avoid forcing unnecessary methods on implementations.
- **Dependency Inversion Principle (DIP):** High-level modules (e.g., the InMemoryDatabase class) depend on abstractions (interfaces), not concrete classes, allowing easier testing and extension.
## Conclusion:
By applying SOLID principles and leveraging design patterns like Factory, Repository, and Strategy, we achieve a clean, maintainable, and extensible design for an in-memory relational database. This design ensures that new functionality can be added with minimal changes to the existing codebase, improving scalability and maintainability.