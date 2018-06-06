namespace SafeGuard.Interfaces
{
    public interface IEncryptViewModel : IEncrypt
    {
        string EncryptInput();
        bool inputChecker();
    }
}
