
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.API
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UserController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser(UserRegistrationDTO user)
        {
            try
            {
                int userId = await _userRegistrationService.CreateUserAsync(user);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistrationDTO>> GetUserById(int id)
        {
            var user = await _userRegistrationService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistrationDTO>>> GetAllUsers()
        {
            var users = await _userRegistrationService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUser(UserRegistrationDTO user)
        {
            try
            {
                bool isUpdated = await _userRegistrationService.UpdateUserAsync(user);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool isDeleted = await _userRegistrationService.DeleteUserAsync(id);
            return Ok(isDeleted);
        }
    }
}
