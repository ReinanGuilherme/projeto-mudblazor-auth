using MudblazorAuth.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace MudblazorAuth.Infrastructure.Security.Cryptography
{
    public class Cryptography : ICryptography
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
