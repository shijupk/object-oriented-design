namespace LibraryManagementSystem.Abstractions;

public abstract class Member
{
    private readonly List<Book> borrowedBooks;
    public string Name { get; }
    public string MemberId { get; private set; }
    public MemberType MemberType { get; private set; }

    public Member(string name, string memberId, MemberType memberType)
    {
        Name = name;
        MemberId = memberId;
        MemberType = memberType;
        borrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (book.Status == BookStatus.Available)
        {
            borrowedBooks.Add(book);
            book.Status = BookStatus.Borrowed;
            Console.WriteLine($"{Name} borrowed the book: {book.Title}");
        }
        else
        {
            Console.WriteLine($"The book {book.Title} is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (borrowedBooks.Contains(book))
        {
            borrowedBooks.Remove(book);
            book.Status = BookStatus.Available;
            Console.WriteLine($"{Name} returned the book: {book.Title}");
        }
        else
        {
            Console.WriteLine($"{Name} did not borrow the book: {book.Title}");
        }
    }
}

public class StudentMember : Member
{
    public StudentMember(string name, string memberId)
        : base(name, memberId, MemberType.Student)
    {
    }
}

public class TeacherMember : Member
{
    public TeacherMember(string name, string memberId)
        : base(name, memberId, MemberType.Teacher)
    {
    }
}