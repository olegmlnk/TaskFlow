using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Core.Abstractions;
using TaskFlow.Core.Models;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;


        public AccountController AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


    }
}
