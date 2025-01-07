using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myportfolio.Models;
namespace myportfolio.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(ApplicationDbContext context)
        {
                userService = new UserService(context);
        }

        // CREATE
        [HttpPost("create")] 
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            User createdUser = await userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // READe
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await  userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await userService.GetUserById(id);
                return user;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
            User updatedUser =     await userService.UpdateUser(id, user);
            return Ok(updatedUser);
                
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
           

        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                User deletedUser = await userService.DeleteUser(id);
                return Ok(deletedUser);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
