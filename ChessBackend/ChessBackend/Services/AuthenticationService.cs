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
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChessBackend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOptions<TokenSettings> _tokenSettings;
        private readonly UserManager<User> _userManager;
        private bool _userExists = false;
        private bool _passwordMatches = false;
        private User _user;

        public AuthenticationService(UserManager<User> userManager, IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings;
            _userManager = userManager;
        }
        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            await GetUser(registerModel.Email);
            CheckIfUserExists(registerModel.Email);

            if (_userExists)
                return null;

            _user = CreateUserWithDataFromRegisterModel(registerModel);
            return await _userManager.CreateAsync(_user, registerModel.Password);
        }
        public async Task<string> Login(LoginModel loginModel)
        {
            await GetUser(loginModel.Email);
            CheckIfUserExists(loginModel.Email);

            if (!_userExists)
                return null;

            CheckIfPasswordsMatch(loginModel.Password);

            if(!_passwordMatches)
                return null;

            return await CreateJwtToken();
        }

        private async void CheckIfPasswordsMatch(string password)
        {
            if (await _userManager.CheckPasswordAsync(_user, password))
                _passwordMatches = true;
        }

        private async Task GetUser(string email)
        {
            _user = await FindUserByEmail(email);
        }

        private void CheckIfUserExists(string email)
        {
            if (_user == null)
                _userExists = false;
            else
                _userExists = true;
        }

        private async Task<string> CreateJwtToken()
        {
            var allClaims = await GetAllClaims();
            var signinCredentials = GetSigningCredentials();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Value.Issuer,
                audience: _tokenSettings.Value.Audience,
                claims: allClaims,
                expires: DateTime.UtcNow.AddMinutes(_tokenSettings.Value.ExpirationTimeInMinutes),
                signingCredentials: signinCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var keyBytes = Encoding.UTF8.GetBytes(_tokenSettings.Value.Key);
            var symmetricSecurityKey = new SymmetricSecurityKey(keyBytes);
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetAllClaims()
        {
            var userClaims = await _userManager.GetClaimsAsync(_user);

            return new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, _user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email)
            }
            .Union(userClaims)
            .ToList();
        }

        private User CreateUserWithDataFromRegisterModel(RegisterModel registerModel)
        {
            return new User()
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
        }

        private async Task<User> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
