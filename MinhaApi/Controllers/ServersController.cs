using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ServersController : ControllerBase
    {
        private readonly IServerService serverService;
        public ServersController(IServerService serverService)
        {
            this.serverService = serverService;

        }

        [HttpGet("GetServers")]
        public IActionResult GetAllServers()
        {
            var allServers = serverService.GetAllServers();

            return Ok(allServers);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetServerByID(Guid id)
        {
            var server = serverService.GetServerById(id);
            if (server is null)
            {
                return NotFound();
            }
            return Ok(server);
        }

        [HttpPost("newServer")]

        public IActionResult AddServer(AddServerDto dto)
        {
            var newServer = serverService.AddServer(dto);
            if (newServer is null)
            {
                return NotFound();
            }
            return Ok(newServer);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteServer(Guid id)
        {
            var deletedServer = serverService.DeleteServer(id);
            if (!deletedServer)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateServer(Guid id, UpdateServerDto dto)
        {
            var UpdateServer = serverService.UpdateServer(id, dto);

            if (!UpdateServer)
            {
                return NotFound();
            }
            return Ok();
        }

    }

}