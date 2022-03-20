using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
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
        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            var users = userService.GetAllUsers();

            if (users == null)
                return BadRequest("Something went wrong");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await userService.GetUserById(id);
            if (user == null)
                return NotFound("Not Found");

            return Ok(user);
        }

        [HttpPut]
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
    }
}
