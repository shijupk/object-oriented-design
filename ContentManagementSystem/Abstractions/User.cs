namespace ContentManagementSystem.Abstractions;

public class User
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public List<Role> Roles { get; }

    public User(string username, string email)
    {
        Username = username;
        Email = email;
        Roles = new List<Role>();
    }

    public void AssignRole(Role role)
    {
        if (!Roles.Contains(role))
        {
            Roles.Add(role);
        }
    }
}

public class Role
{
    public string Name { get; private set; }
    public List<Permission> Permissions { get; }

    public Role(string name)
    {
        Name = name;
        Permissions = new List<Permission>();
    }

    public void AddPermission(Permission permission)
    {
        if (!Permissions.Contains(permission))
        {
            Permissions.Add(permission);
        }
    }
}

public class Permission
{
    public string Name { get; private set; }

    public Permission(string name)
    {
        Name = name;
    }
}