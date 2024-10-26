using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using user_crud.Data;
using user_crud.Models;

namespace user_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public UserController(UserContext userContext)
        {
            _dbContext = userContext;
        }

        //CRUD - CREATE READ UPDATE DELETE

        [HttpPost("Add User Information")]
        public async Task<ActionResult> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(user), new { id = user.Id }, user);
        }

        [HttpGet("Get User List")]
        public async Task<ActionResult<List<UserModel>>> ShowList()
        {
            if(_dbContext.Users == null)
                return NotFound("There are no users.");

            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPut("Update User Information")]
        public async Task<ActionResult> UpdateUser(int id, UserModel user)
        {
            //get user from database
            var dbUser = await _dbContext.Users.FindAsync(id);

            //check if the user exists
            if(dbUser == null)
                return NotFound($"User with id {id} does not exist.");

            //update user properties
            dbUser.Username = user.Username;
            dbUser.Address = user.Address;
            dbUser.PhoneNumber = user.PhoneNumber;
            dbUser.Zip = user.Zip;
            dbUser.Email = user.Email;

            await _dbContext.SaveChangesAsync();

            return Ok("User information was changed.");
        }

        [HttpDelete("Delete User")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if(_dbContext.Users == null)
                return BadRequest("There are no users to delete.");

            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound($"User with id {id} does not exist.");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return Ok("User deleted.");
        }

    }
}
