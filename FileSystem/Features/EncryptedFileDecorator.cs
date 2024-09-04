using FileSystem.Abstractions;

namespace FileSystem.Features;

public class EncryptedFileDecorator : IFileOperations
{
    private readonly byte _encryptionKey;
    private readonly IFileOperations _file;

    public EncryptedFileDecorator(IFileOperations file, byte encryptionKey)
    {
        _file = file;
        _encryptionKey = encryptionKey;
    }

    public byte[] Read()
    {
        // Read the encrypted data
        var encryptedData = _file.Read();

        // Decrypt the data
        return EncryptDecrypt(encryptedData);
    }

    public void Write(byte[] data)
    {
        // Encrypt the data
        var encryptedData = EncryptDecrypt(data);

        // Write the encrypted data
        _file.Write(encryptedData);
    }

    private byte[] EncryptDecrypt(byte[] data)
    {
        var result = new byte[data.Length];

        for (var i = 0; i < data.Length; i++)
        {
            result[i] = (byte)(data[i] ^ _encryptionKey); // Simple XOR encryption
        }

        return result;
    }
}