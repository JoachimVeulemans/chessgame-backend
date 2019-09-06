using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Entities;
using ChessBackend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChessBackend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOptions<TokenSettings> _tokenSettings;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(UserManager<User> userManager, IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings;
            _userManager = userManager;
        }
        public async Task<string> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if(user == null)
            {
                return null;
            }

            if(!await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return null;
            }

            return await CreateJwtToken(user);
        }
        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            var user = await _userManager.FindByEmailAsync(registerModel.Email);

            if(user != null)
            {
                return null;
            }

            user = new User
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            return await _userManager.CreateAsync(user, registerModel.Password);
        }
        private async Task<string> CreateJwtToken(User user)
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
