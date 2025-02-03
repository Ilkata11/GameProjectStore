using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BL.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
    }
}
