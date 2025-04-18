using TaskFlow.Core.Models;

namespace TaskFlow.Core
{
    public interface IJwtProvider
    {
        string GenerateToken(User user, IList<string> roles);
    }
}