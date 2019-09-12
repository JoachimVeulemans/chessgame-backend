using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Entities.Models
{
    public class GetValidPositionsModel
    {
        public string GameId { get; set; }
        public string Position { get; set; }
    }
}
