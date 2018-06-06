using SafeGuard.Enum;

namespace SafeGuard.Interfaces
{
    public interface IEncrypt
    {
        EncryptionType encryptionType { get; set; }
        string encryptionKey { get; set; }
        bool mustBeEncrypted { get; set; }
        string inputText { get; set; }
    }
}
