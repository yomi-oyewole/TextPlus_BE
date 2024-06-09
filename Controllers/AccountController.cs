using Microsoft.AspNetCore.Mvc;
using TextPlus_BE.Dto;
using TextPlus_BE.Helper.Security;
using TextPlus_BE.Interfaces;
using TextPlus_BE.Model;

namespace TextPlus_BE.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        private readonly IUserRepository userRepository;
        private readonly ILoginRepository loginRepository;
        private readonly IJwtProvider jwtProvider;
        public AccountController(IServiceProvider serviceProvider)
        {
            userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            loginRepository = serviceProvider.GetRequiredService<ILoginRepository>();
            jwtProvider = serviceProvider.GetRequiredService<IJwtProvider>();
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await userRepository.RegisterAsync(model);
            _ = await loginRepository.AddLoginContextAsync(model.Password!, user.Id.ToString(), model.Email!);
            var token = jwtProvider.GenerateJwtToken(user);

            var response = new Dictionary<string, object>
            {
                { "user", user },
                { "token", token }
            };

            return Ok(response);
        }

        // Login a user
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var isValid = await loginRepository.LoginAsync(model);
            if (!isValid)
                return Unauthorized("Invalid email or password");

            var user = await userRepository.GetUserByEmailAsync(model.Email!);
            var token = jwtProvider.GenerateJwtToken(user);
            var response = new Dictionary<string, object>
            {
                { "user", user },
                { "token", token }
            };
            return Ok(response);
        }

        // Get user profile
        [HttpGet("user")]
        //[Authenticate]
        public async Task<IActionResult> GetUser([FromQuery] string email)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
    }
}
