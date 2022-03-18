using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.WebApi.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("login")]
        public ActionResult<UserResponse> Login(UserLoginRequest userLoginRequest)
        {
            var user = accountService.Login(userLoginRequest);

            if(user == null)
                return NotFound("Email not found");

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(UserRegisterRequest userCreateRequest)
        {
            var user = await accountService.Register(userCreateRequest);

            if (user == null)
                return BadRequest("Username or Email already exists");

            return Ok(user);
        }

    }
}
