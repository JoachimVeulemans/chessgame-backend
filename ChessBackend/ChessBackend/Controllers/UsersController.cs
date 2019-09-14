using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Entities;
using ChessBackend.Entities.Models;
using ChessBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(string id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] UserModel userModel )
        {
            var user = new User(id, userModel);
            await _userService.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [HttpGet("/me")]
        public async Task<IActionResult> GetMe()
        {
            return Ok(await _userService.GetByIdAsync(ApplicationUtilities.GetUserIdFromHttpContext(HttpContext)));
        }

    }
}