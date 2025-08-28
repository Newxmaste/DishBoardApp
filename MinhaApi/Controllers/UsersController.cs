using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.DTO;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserByID(Guid id)
        {
            var user = userService.GetUserById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }



        [HttpPost("newUser")]
        public IActionResult AddUser(AddUserDto dto)
        {
            var newUser = userService.AddUser(dto);
            if (newUser is null)
            {
                return NotFound();
            }

            return Ok(newUser);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto dto)
        {
            var updatedUser = userService.UpdateUser(id, dto);

            if (!updatedUser)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteUser(Guid id)
        {
            var deletedUser = userService.DeleteUser(id);
            if (!deletedUser)
            {
                return NotFound();
            }
            return Ok();
        }

        // [HttpGet("test")]
        // public IActionResult Test()
        // {
        //     Console.WriteLine("=== Test() foi chamado ===");
        //     return Ok("Test endpoint funcionando!");
        // }
    }
}