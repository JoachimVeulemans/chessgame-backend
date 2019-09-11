using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChessBackend.Entities
{
    public static class ApplicationUtilities
    {
        public static string GetUserIdFromHttpContext(HttpContext httpContext)
        {
            return httpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(p => p.Value).FirstOrDefault();
        }
    }
}
