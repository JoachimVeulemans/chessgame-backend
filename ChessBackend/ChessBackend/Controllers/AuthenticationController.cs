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
        private readonly IOptions<TokenSettings> _tokenSettings;
        private readonly UserManager<User> _userManager;
        public AuthenticationController(UserManager<User> userManager, IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                return BadRequest();
            }

            user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { Username = user.UserName });
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

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized();
            }

            var token = await CreateJwtToken(user);

            return Ok(new { signinToken = token, });
        }

        public async Task<string> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var allClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(userClaims)
            .ToList();

            var keyBytes = Encoding.UTF8.GetBytes(_tokenSettings.Value.Key);
            var symmetricSecurityKey = new SymmetricSecurityKey(keyBytes);
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Value.Issuer,
                audience: _tokenSettings.Value.Audience,
                claims: allClaims,
                expires: DateTime.UtcNow.AddMinutes(_tokenSettings.Value.ExpirationTimeInMinutes),
                signingCredentials: signinCredentials
                );

            string encryptedToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return encryptedToken;
        }
    }
}