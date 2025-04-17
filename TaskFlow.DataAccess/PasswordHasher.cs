using TaskFlow.Core.Abstractions;

namespace TaskFlow.DataAccess
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
