using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Application.Interfaces.Repositories;
using UserAPI.Domain.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("new-user")]
        public async Task<IActionResult>CreatedUser(User user)
        {
            var createdUser = await _userRepo.CreateUser(user);

            if(createdUser == false)
            {
                return BadRequest(new { code = 400, message = "Bad Request", status = false });
            }

            return Ok(new { code = 200, message = "User Created Successfully", status = true });
        }

        [HttpPut("log-daily-data")]
        public async Task<IActionResult>LogDailyData(DailyEntry dailyEntry)
        {
            var loggedData = await _userRepo.LoggedData(dailyEntry);
            if(loggedData == false)
            {
                return NotFound(new { code = 404, message = "User Not Found", status = false });
            }

            return Ok(new { code = 200, message = "Daily Data Logged Successfully", status = true });
        }
    }
}
