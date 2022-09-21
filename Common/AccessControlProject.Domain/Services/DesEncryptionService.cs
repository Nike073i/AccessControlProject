using AccessControlProject.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace AccessControlProject.Domain.Services
{
    public class DesEncryptionService : IEncryptionService
    {
        public bool EncryptFile(string fileInPath, string fileOutPath, string key)
        {
            var bytesFromKey = Encoding.ASCII.GetBytes(key);
            if (bytesFromKey.Length != 8) return false;
            try
            {
                using var des = DES.Create();
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
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
            return true;
        }

        public bool DecryptFile(string fileInPath, string fileOutPath, string key)
        {
            var bytesFromKey = Encoding.ASCII.GetBytes(key);
            if (bytesFromKey.Length != 8) return false;
            try
            {
                using var des = DES.Create();
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
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
            return true;
        }
    }
}
