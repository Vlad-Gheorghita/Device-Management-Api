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
    //[Authorize]
    public class DeviceController : ApiControllerBase
    {
        private readonly IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceResponse>>> GetAllDevices()
        {
            var deviceList = await deviceService.GetAllDevices();

            return Ok(deviceList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id)
        {
            return Ok(await deviceService.GetDeviceById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddDevice(DeviceCreateRequest deviceCreateRequest)
        {
            if (!(await deviceService.AddDevice(deviceCreateRequest)))
                return BadRequest("Something went wrong");

            return Ok("Device added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            if (!(await deviceService.DeleteDevice(id)))
                return BadRequest("Something went wrong");

            return Ok("Device deleted");
        }

        [HttpPut]
        public async Task<ActionResult> EditDevice(DeviceUpdateRequest deviceUpdateRequest)
        {
            if(!(await deviceService.UpdateDevice(deviceUpdateRequest)))
                return NotFound();

            return Ok(deviceUpdateRequest);
        }


    }
}
