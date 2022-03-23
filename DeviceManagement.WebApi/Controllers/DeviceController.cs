using AutoMapper;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Models.Device;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.WebApi.Controllers
{

    public class DeviceController : ApiControllerBase
    {
        private readonly IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpGet("devices")]
        public async Task<ActionResult<List<DeviceResponse>>> GetAllDevices()
        {
            var deviceList = await deviceService.GetAllDevices();

            return Ok(deviceList.ToList());
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id)
        {
            return Ok(await deviceService.GetDeviceById(id));
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("add")]
        public async Task<ActionResult> AddDevice(DeviceCreateRequest deviceCreateRequest)
        {
            if (!(await deviceService.AddDevice(deviceCreateRequest)))
                return BadRequest("Something went wrong or device already exists");

            return Ok("Device added successfully");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete-device/{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            if (!(await deviceService.DeleteDevice(id)))
                return BadRequest("Something went wrong");

            return Ok("Device deleted");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("edit")]
        public async Task<ActionResult> EditDevice(DeviceUpdateRequest deviceUpdateRequest)
        {
            if (!(await deviceService.UpdateDevice(deviceUpdateRequest)))
                return NotFound();

            return Ok(deviceUpdateRequest);
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpPut("assign-device/{deviceId}/{userId}")]
        public async Task<ActionResult> AssignUserToDevice(int deviceId, int userId)
        {
            var res = await deviceService.UpdateDeviceUser(deviceId, userId);
            if (res == null)
                return NotFound("User or device not found");

            return Ok(res);
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpPut("unassign-device/{deviceId}")]
        public async Task<ActionResult> UnassignUserFromDevice(int deviceId)
        {
            var res = await deviceService.UpdateDeviceUser(deviceId, 0);
            if (res == null)
                return NotFound("User or device not found");

            return Ok(res);
        }

    }
}
