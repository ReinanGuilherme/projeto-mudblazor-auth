namespace MudblazorAuth.Domain.Security.Cryptography
{
    public interface ICryptography
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHash);
    }
}
