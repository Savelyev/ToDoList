using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TodoList.JwtFeatures;
using TodoList.Models;
using TodoList.ViewModel;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly JwtHandler jwtHandler;

        public AccountsController(UserManager<User> userManager, JwtHandler jwtHandler)
        {
            this.userManager = userManager;
            this.jwtHandler = jwtHandler;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterViewModel registerViewModel)
        {
            if (registerViewModel == null || !ModelState.IsValid)
                return BadRequest();

            var result = await userManager.CreateAsync(
                new User { Email = registerViewModel.Email, UserName = registerViewModel.Email }, 
                registerViewModel.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegisterResponseViewModel { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginViewModel.Password))
            {
                return Unauthorized(new AuthResponseViewModel { ErrorMessage = "Invalid Authentication" });
            }
            var signingCredentials = jwtHandler.GetSigningCredentials();
            var claims = jwtHandler.GetClaims(user);
            var tokenOptions = jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseViewModel { IsAuthSuccessful = true, Token = token });
        }
    }
}
