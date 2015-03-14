namespace BlogIT.Utility
{
    public interface IEncryptDecrypt
    {
        string EncryptedText(string text, string key);
        string DecryptedText(string text, string key);
    }
}