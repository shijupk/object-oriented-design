namespace LibraryManagementSystem.Abstractions;

public enum BookStatus
{
    Available,
    Borrowed,
    Reserved,
    Lost
}

public enum MemberType
{
    Student,
    Teacher,
    Librarian
}

public interface ISearchable
{
    List<Book> SearchByTitle(string title);
    List<Book> SearchByAuthor(string author);
    List<Book> SearchBySubject(string subject);
}

public interface IBorrowable
{
    void BorrowBook(Book book, Member member);
    void ReturnBook(Book book, Member member);
}

public interface IReservable
{
    void ReserveBook(Book book, Member member);
}