using LibraryManagementSystem.Abstractions;

namespace LibraryManagementSystem.Features;

public class Catalog : ISearchable
{
    private readonly List<Book> _books;

    public Catalog()
    {
        _books = new List<Book>();
    }

    public List<Book> SearchByTitle(string title)
    {
        return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchByAuthor(string author)
    {
        return _books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchBySubject(string subject)
    {
        return _books.Where(b => b.Subject.Contains(subject, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        _books.Remove(book);
    }
}