using System.Text;
using FileSystem.Abstractions;
using FileSystem.Features;
using Directory = FileSystem.Features.Directory;
using File = FileSystem.Features.File;

public class Program
{
    public static void Main(string[] args)
    {
        // Set up access control
        var accessControlService = AccessControlService.Instance;

        // Create a user
        var user = new User("U001", "Alice", "user@gmail.com");

        // Create storage service
        IStorageService storageService = new LocalStorageService();

        // Set up file system service
        var fileSystemService = new FileSystemService(accessControlService);

        // Create a directory
        var directory = new Directory("MyDocuments", "/documents");
        accessControlService.GrantAccess(user, directory);
        fileSystemService.CreateDirectory("MyDocuments", "/documents", user);

        // Create a file
        fileSystemService.CreateFile("MyFile.txt", "/documents/MyFile.txt", storageService, user);

        // Write data to file
        var file = new File("MyFile.txt", "/documents/MyFile.txt", storageService);
        file.Write(Encoding.UTF8.GetBytes("Hello, world!"));

        // Read data from file
        var data = file.Read();
        Console.WriteLine($"Read from file: {Encoding.UTF8.GetString(data)}");

        // Delete file
        fileSystemService.DeleteFile(file, user);

        // Delete directory
        fileSystemService.DeleteDirectory(directory, user);


        //Use  of decorator

        //IStorageService storageService = new LocalStorageService();

        //// Create a plain file
        //IFileOperations file = new File("/documents/SecretFile.txt", storageService);

        //// Decorate the file with encryption
        //IFileOperations encryptedFile = new EncryptedFileDecorator(file, encryptionKey: 0xFF);

        //// Write data to the encrypted file
        //encryptedFile.Write(Encoding.UTF8.GetBytes("Top Secret Information"));

        //// Read data from the encrypted file
        //var data = encryptedFile.Read();
        //Console.WriteLine($"Decrypted content: {Encoding.UTF8.GetString(data)}");
    }
}