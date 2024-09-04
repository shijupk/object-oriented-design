namespace FileSystem.Abstractions;

public abstract class FileSystemObject : IFileSystemObject
{
    protected FileSystemObject(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; protected set; }
    public string Path { get; protected set; }

    public abstract void Delete();
}