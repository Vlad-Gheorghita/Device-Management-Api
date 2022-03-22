using AutoMapper;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;
using DeviceManagement.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public async Task<ActionResult<List<DeviceResponse>>> GetAllDevices()
        {
            var deviceList = await deviceService.GetAllDevices();

            return Ok(deviceList.ToList()); //nu stiu daca e de aici 
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id)
        {
            return Ok(await deviceService.GetDeviceById(id));
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost]
        public async Task<ActionResult> AddDevice(DeviceCreateRequest deviceCreateRequest)
        {
            if (!(await deviceService.AddDevice(deviceCreateRequest)))
                return BadRequest("Something went wrong");

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
        [HttpPut]
        public async Task<ActionResult> EditDevice(DeviceUpdateRequest deviceUpdateRequest)
        {
            if(!(await deviceService.UpdateDevice(deviceUpdateRequest)))
                return NotFound();

            return Ok(deviceUpdateRequest);
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateDeviceUser(int userId)
        {
            return Ok();
        }


    }
}
