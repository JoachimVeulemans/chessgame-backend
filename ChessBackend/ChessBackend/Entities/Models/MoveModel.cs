﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Entities.Models
{
    public class MoveModel
    {
        public string GameId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
