using LibraryManagementSystem.Abstractions;

namespace LibraryManagementSystem.Features;

public class Library : IBorrowable, IReservable
{
    private readonly Catalog _catalog;
    private readonly Dictionary<Book, Member> _loanedBooks;
    private List<Member> _members;

    public Library(Catalog catalog)
    {
        _catalog = catalog;
        _members = new List<Member>();
        _loanedBooks = new Dictionary<Book, Member>();
    }

    public void BorrowBook(Book book, Member member)
    {
        member.BorrowBook(book);
        if (book.Status == BookStatus.Borrowed)
        {
            _loanedBooks[book] = member;
        }
    }

    public void ReturnBook(Book book, Member member)
    {
        member.ReturnBook(book);
        if (book.Status == BookStatus.Available)
        {
            _loanedBooks.Remove(book);
        }
    }

    public void ReserveBook(Book book, Member member)
    {
        if (book.Status == BookStatus.Available)
        {
            book.Status = BookStatus.Reserved;
            Console.WriteLine($"{member.Name} reserved the book: {book.Title}");
        }
        else
        {
            Console.WriteLine($"The book {book.Title} is not available for reservation.");
        }
    }

    public void AddBook(Book book)
    {
        _catalog.AddBook(book);
    }

    public void RemoveBook(Book book)
    {
        _catalog.RemoveBook(book);
    }

    public List<Book> SearchByTitle(string title)
    {
        return _catalog.SearchByTitle(title);
    }

    public List<Book> SearchByAuthor(string author)
    {
        return _catalog.SearchByAuthor(author);
    }

    public List<Book> SearchBySubject(string subject)
    {
        return _catalog.SearchBySubject(subject);
    }
}