using FileSystem.Abstractions;

namespace FileSystem.Features;

public class AccessControlService : IAccessControl
{
    private static AccessControlService _instance;
    private readonly Dictionary<User, List<FileSystemObject>> _permissions;

    public static AccessControlService Instance => _instance ??= new AccessControlService();

    private AccessControlService()
    {
        _permissions = new Dictionary<User, List<FileSystemObject>>();
    }

    public bool HasAccess(User user, FileSystemObject obj)
    {
        return _permissions.ContainsKey(user) && _permissions[user].Contains(obj);
    }

    public void GrantAccess(User user, FileSystemObject obj)
    {
        if (!_permissions.ContainsKey(user))
        {
            _permissions[user] = new List<FileSystemObject>();
        }

        _permissions[user].Add(obj);
        Console.WriteLine($"Access granted to {user.Name} for {obj.Name}");
    }

    public void RevokeAccess(User user, FileSystemObject obj)
    {
        _permissions[user]?.Remove(obj);
        Console.WriteLine($"Access revoked from {user.Name} for {obj.Name}");
    }
}