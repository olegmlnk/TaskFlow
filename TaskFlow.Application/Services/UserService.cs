using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TaskFlow.Core;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;

namespace TaskFlow.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;

        public UserService(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IJwtProvider jwtProvider,
            ILogger<UserService> logger,
            UserManager<User> userManager)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> Register(string username, string email, string password)
        {
            var user = new User
            (
                username: username,
                passwordHash: _passwordHasher.GenerateHash(password),
                email: email,
                tasks: new List<TaskModel>() 
            );

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description));

            await _userManager.AddToRoleAsync(user, "User");

            return (true, null);
        }

        public async Task<(string Token, string Error)> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                _logger.LogWarning("User not found: {Username}", username);
                return (null, string.Empty);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtProvider.GenerateToken(user, roles.ToList());

            return (token, null);
        }
    }
}
