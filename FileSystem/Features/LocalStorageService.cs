using FileSystem.Abstractions;

namespace FileSystem.Features;

public class LocalStorageService : IStorageService
{
    public void Save(string path, byte[] data)
    {
        try
        {
            // Ensure the directory exists
            var directory = Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            // Write the data to the file
            System.IO.File.WriteAllBytes(path, data);
            Console.WriteLine($"File saved to {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file to {path}: {ex.Message}");
        }
    }

    public byte[] Load(string path)
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                // Read the data from the file
                var data = System.IO.File.ReadAllBytes(path);
                Console.WriteLine($"File loaded from {path}");
                return data;
            }

            Console.WriteLine($"File not found: {path}");
            return Array.Empty<byte>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file from {path}: {ex.Message}");
            return Array.Empty<byte>();
        }
    }

    public void Delete(string path)
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                // Delete the file
                System.IO.File.Delete(path);
                Console.WriteLine($"File deleted from {path}");
            }
            else
            {
                Console.WriteLine($"File not found: {path}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file from {path}: {ex.Message}");
        }
    }
}