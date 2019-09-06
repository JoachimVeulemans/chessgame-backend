using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Entities.Models
{
    public class LoginModel
    {
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}
