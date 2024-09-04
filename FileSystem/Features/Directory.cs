using FileSystem.Abstractions;

namespace FileSystem.Features;

public class Directory : FileSystemObject, IDirectoryOperations
{
    private readonly List<FileSystemObject> _children;

    public Directory(string name, string path) : base(name, path)
    {
        _children = new List<FileSystemObject>();
    }

    public void Add(FileSystemObject obj)
    {
        _children.Add(obj);
    }

    public void Remove(FileSystemObject obj)
    {
        _children.Remove(obj);
    }

    public List<FileSystemObject> GetChildren()
    {
        return _children;
    }

    public override void Delete()
    {
        foreach (var child in _children)
        {
            child.Delete();
        }

        Console.WriteLine($"Directory {Name} and all its contents have been deleted.");
    }
}