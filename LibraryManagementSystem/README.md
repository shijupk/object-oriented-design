# Library Management System

Designing a Library Management System (LMS) in C# involves creating classes and interfaces to manage various aspects such as books, users (members), borrowing/lending operations, and fines. The system should adhere to the SOLID principles, ensuring that it is maintainable, scalable, and flexible.

## High-Level Design

### Single Responsibility Principle (SRP)

**Book:** Manages the information related to books.
**Member:** Represents a library member and handles member-related operations.
**Librarian:** Manages library operations, including adding/removing books.
**Library:** Oversees the overall management of the library.
**Loan:** Handles the borrowing and returning of books.
**Catalog:** Manages the searching and listing of books.

### Open/Closed Principle (OCP)

The system should allow adding new types of users (e.g., Student, Teacher) or new features (e.g., e-books) without modifying existing classes.

### Liskov Substitution Principle (LSP)

Derived classes like StudentMember or TeacherMember should be able to replace the base Member class without altering the correctness of the program.

### Interface Segregation Principle (ISP)

Define small, focused interfaces like ISearchable, IBorrowable, and IReservable so that classes only need to implement the methods they actually use.

### Dependency Inversion Principle (DIP)

High-level modules like Library should depend on abstractions (interfaces) rather than concrete implementations.

## Key Points

**Book:** Represents a book in the library.
**Member:** Represents different types of library members (students, teachers).
**Librarian:** Handles administrative tasks like adding and