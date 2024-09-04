namespace RideSharingService.Abstractions;

public abstract class User
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }

    protected User(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}