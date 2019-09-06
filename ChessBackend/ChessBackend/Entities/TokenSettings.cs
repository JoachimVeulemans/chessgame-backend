using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Entities
{
    public class TokenSettings
    {
        public virtual string Key { get; set; }
        public virtual string Issuer { get; set; }
        public virtual string Audience { get; set; }
        public virtual int ExpirationTimeInMinutes { get; set; }
    }
}
