using TaskFlow.Core.Models;

namespace TaskFlow.Core.Abstractions
{
    public interface IUserRepository
    {
        Task<long> DeleteUser(long id);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
    }
}
