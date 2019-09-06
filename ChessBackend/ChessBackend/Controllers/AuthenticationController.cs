using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Entities;
using ChessBackend.Entities.Models;
using ChessBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChessBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authenticationService.Register(model);

            if(result == null)
            {
                return BadRequest();
            }

            if (result.Succeeded)
            {
                return Ok(new { Username = model.UserName });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authenticationService.Login(model);

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(new { signinToken = token, });
        }
    }
}