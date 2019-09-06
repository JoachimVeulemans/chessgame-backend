using ChessBackend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(RegisterModel registerModel);
        Task<string> Login(LoginModel loginModel);
    }
}
