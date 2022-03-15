using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
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

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            userService.Create(user);
            return Ok(user);
        }
    }
}
