
namespace TaskFlow.Core.Abstractions
{
    public interface IUserService
    {
        Task<(string Token, string Error)> Login(string username, string password);
        Task<(bool Success, IEnumerable<string> Errors)> Register(string username, string email, string password);
    }
}