namespace FileSystem.Abstractions;

public interface IFileSystemObject
{
    string Name { get; }
    string Path { get; }
    void Delete();
}

public interface IFileOperations
{
    byte[] Read();
    void Write(byte[] data);
}

public interface IDirectoryOperations
{
    void Add(FileSystemObject obj);
    void Remove(FileSystemObject obj);
    List<FileSystemObject> GetChildren();
}

public interface IAccessControl
{
    bool HasAccess(User user, FileSystemObject obj);
}

public interface IStorageService
{
    void Save(string path, byte[] data);
    byte[] Load(string path);
    void Delete(string path);
}