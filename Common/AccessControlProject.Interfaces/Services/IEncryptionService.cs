namespace AccessControlProject.Interfaces.Services
{
    public interface IEncryptionService
    {
        bool EncryptFile(string fileInPath, string fileOutPath, string key);
        bool DecryptFile(string fileInPath, string fileOutPath, string key);
    }
}
