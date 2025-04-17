namespace TaskFlow.Core.Abstractions
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
