using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;

namespace TaskFlow.Application.Services
{
    public  class UserService
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

    }
}
