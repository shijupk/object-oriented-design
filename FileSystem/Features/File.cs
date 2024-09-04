using FileSystem.Abstractions;

namespace FileSystem.Features;

public class File : FileSystemObject, IFileOperations
{
    private readonly IStorageService _storageService;

    public File(string name, string path, IStorageService storageService) : base(name, path)
    {
        _storageService = storageService;
    }

    public byte[] Read()
    {
        return _storageService.Load(Path);
    }

    public void Write(byte[] data)
    {
        _storageService.Save(Path, data);
    }

    public override void Delete()
    {
        _storageService.Delete(Path);
        Console.WriteLine($"File {Name} deleted.");
    }
}