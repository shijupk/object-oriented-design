namespace LibraryManagementSystem.Abstractions;

public class Book
{
    public string ISBN { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Subject { get; private set; }
    public BookStatus Status { get; set; }

    public Book(string isbn, string title, string author, string subject)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        Subject = subject;
        Status = BookStatus.Available;
    }
}