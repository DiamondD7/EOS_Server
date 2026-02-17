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

        [HttpPost("user-identity")]
        public async Task<IActionResult>CheckUserIdentity(User user)
        {
            var userIdentity = await _userRepo.CheckUserIdentityAsync(user);
            if(userIdentity == 0)
            {
                return NotFound(new { code = 404, message = "User Not Found", status = false });
            }
            return Ok(new { code = 200, message = "User Found", status = true, userId = userIdentity });
        }

        [HttpPost("new-user")]
        public async Task<IActionResult>CreatedUser(User user)
        {
            var createdUser = await _userRepo.CreateUserAsync(user);

            if(createdUser == false)
            {
                return BadRequest(new { code = 400, message = "Bad Request", status = false });
            }

            return Ok(new { code = 200, message = "User Created Successfully", status = true });
        }

        [HttpPost("log-daily-data")]
        public async Task<IActionResult>LogDailyData(DailyEntryDTO dailyEntryModel)
        {
            var loggedData = await _userRepo.LoggedDataAsync(dailyEntryModel);
            if(loggedData == false)
            {
                return NotFound(new { code = 404, message = "User Not Found", status = false });
            }

            return Ok(new { code = 200, message = "Daily Data Logged Successfully", status = true });
        }
    }
}
