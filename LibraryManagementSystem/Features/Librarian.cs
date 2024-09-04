using LibraryManagementSystem.Abstractions;

namespace LibraryManagementSystem.Features;

public class Librarian : Member
{
    private readonly Library _library;

    public Librarian(string name, string memberId, Library library)
        : base(name, memberId, MemberType.Librarian)
    {
        _library = library;
    }

    public void AddBook(Book book)
    {
        _library.AddBook(book);
        Console.WriteLine($"Librarian {Name} added the book: {book.Title}");
    }

    public void RemoveBook(Book book)
    {
        _library.RemoveBook(book);
        Console.WriteLine($"Librarian {Name} removed the book: {book.Title}");
    }
}