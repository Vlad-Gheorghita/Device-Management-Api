using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.WebApi.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users")]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            var users = userService.GetAllUsers();

            if (users == null)
                return BadRequest("Something went wrong");

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await userService.GetUserById(id);
            if (user == null)
                return NotFound("Not Found");

            return Ok(user);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("update")]
        public async Task<ActionResult> UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            if (!(await userService.UpdateUser(userUpdateRequest)))
                return BadRequest();

            return Ok(userUpdateRequest);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if(!(await userService.DeleteUser(id)))
                return BadRequest();

            return Ok("User Deleted Successfully");
        }

        [AllowAnonymous]
        [HttpPut("update-user-location")]
        public async Task<ActionResult> UpdateUserLocation(UserUpdateLocationRequest userUpdateLocationRequest)
        {
            var res = await userService.UpdateUserLocation(userUpdateLocationRequest);

            if (res == null)
                return NotFound("User not found");

            return Ok(res);
        }
    }
}
