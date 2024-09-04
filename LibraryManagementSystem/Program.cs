using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.Features;

namespace LibraryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Create catalog
        var catalog = new Catalog();

        // Create library
        var library = new Library(catalog);

        // Create librarian
        var librarian = new Librarian("Alice", "L001", library);

        // Add books to the library
        librarian.AddBook(new Book("123456", "C# Programming", "John Doe", "Programming"));
        librarian.AddBook(new Book("789101", "Design Patterns", "Jane Smith", "Software Engineering"));

        // Create members
        var student = new StudentMember("Bob", "S001");
        var teacher = new TeacherMember("Charlie", "T001");

        // Borrow a book
        var books = library.SearchByTitle("C# Programming");
        if (books.Any())
        {
            var bookToBorrow = books.First();
            library.BorrowBook(bookToBorrow, student);
        }

        // Return a book
        if (books.Any())
        {
            var bookToReturn = books.First();
            library.ReturnBook(bookToReturn, student);
        }

        // Reserve a book
        books = library.SearchByTitle("Design Patterns");
        if (books.Any())
        {
            var bookToReserve = books.First();
            library.ReserveBook(bookToReserve, teacher);
        }
    }
}