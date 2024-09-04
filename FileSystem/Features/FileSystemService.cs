using FileSystem.Abstractions;

namespace FileSystem.Features;

public class FileSystemService
{
    private readonly IAccessControl _accessControl;

    public FileSystemService(IAccessControl accessControl)
    {
        _accessControl = accessControl;
    }

    public void CreateFile(string name, string path, IStorageService storageService, User user)
    {
        if (!_accessControl.HasAccess(user, new File(name, path, storageService)))
        {
            Console.WriteLine("Access Denied: You do not have permission to create a file here.");
            return;
        }

        var file = new File(name, path, storageService);
        Console.WriteLine($"File {name} created at {path}");
    }

    public void CreateDirectory(string name, string path, User user)
    {
        if (!_accessControl.HasAccess(user, new Directory(name, path)))
        {
            Console.WriteLine("Access Denied: You do not have permission to create a directory here.");
            return;
        }

        var directory = new Directory(name, path);
        Console.WriteLine($"Directory {name} created at {path}");
    }

    public void DeleteFile(File file, User user)
    {
        if (_accessControl.HasAccess(user, file))
        {
            file.Delete();
        }
        else
        {
            Console.WriteLine("Access Denied: You do not have permission to delete this file.");
        }
    }

    public void DeleteDirectory(Directory directory, User user)
    {
        if (_accessControl.HasAccess(user, directory))
        {
            directory.Delete();
        }
        else
        {
            Console.WriteLine("Access Denied: You do not have permission to delete this directory.");
        }
    }
}