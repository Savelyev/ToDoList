using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.ViewModel;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        public AccountsController(UserManager<User> userManager)
        {
            this.userManager = userManager;
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
    }
}
