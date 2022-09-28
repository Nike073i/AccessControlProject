using System.Security.Cryptography;
using System.Text;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services;

public class DesEncryptionService : IEncryptionService
{
    public bool EncryptFile(string fileInPath, string fileOutPath, string key)
    {
        if (string.IsNullOrEmpty(fileInPath) || string.IsNullOrEmpty(fileOutPath) || string.IsNullOrEmpty(key))
            throw new ArgumentException("Были получены некорректные входные значения");
        if (!File.Exists(fileInPath))
            throw new FileNotFoundException("Указанный файл не существует", fileInPath);
        var bytesFromKey = Encoding.ASCII.GetBytes(key);
        if (bytesFromKey.Length != 8)
            throw new ArgumentException("Значение ключа должно быть 64-битным!");
        try
        {
            using var des = DES.Create();
            //des.Mode = CipherMode.OFB; //.NET не поддерживает OFB и CFB. Поэтому используется CBC
            using var encryption = des.CreateEncryptor(bytesFromKey, bytesFromKey);

            using var fInStream = File.Open(fileInPath, FileMode.Open);
            using var fOutStream = File.Open(fileOutPath, FileMode.OpenOrCreate);
            using var cStream = new CryptoStream(fOutStream, encryption, CryptoStreamMode.Write);

            var inputBytes = new byte[fInStream.Length];
            fInStream.Read(inputBytes, 0, inputBytes.Length);
            cStream.Write(inputBytes, 0, inputBytes.Length);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Ошибка шифрования файла: {0}", e.Message);
            throw;
        }

        return true;
    }

    public bool DecryptFile(string fileInPath, string fileOutPath, string key)
    {
        if (string.IsNullOrEmpty(fileInPath) || string.IsNullOrEmpty(fileOutPath) || string.IsNullOrEmpty(key))
            throw new ArgumentException("Были получены некорректные входные значения");
        if (!File.Exists(fileInPath))
            throw new FileNotFoundException("Указанный файл не существует", fileInPath);
        var bytesFromKey = Encoding.ASCII.GetBytes(key);
        if (bytesFromKey.Length != 8)
            throw new ArgumentException("Значение ключа должно быть 64-битным!");
        try
        {
            using var des = DES.Create();
            //des.Mode = CipherMode.OFB; //.NET не поддерживает OFB и CFB. Поэтому используется CBC
            using var decryption = des.CreateDecryptor(bytesFromKey, bytesFromKey);

            using var fInStream = File.OpenRead(fileInPath);
            using var fOutStream = File.Open(fileOutPath, FileMode.OpenOrCreate);
            using var cStream = new CryptoStream(fOutStream, decryption, CryptoStreamMode.Write);

            var inputBytes = new byte[fInStream.Length];
            fInStream.Read(inputBytes, 0, inputBytes.Length);
            cStream.Write(inputBytes, 0, inputBytes.Length);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Ошибка расшифрования файла: {0}", e.Message);
            throw;
        }

        return true;
    }
}