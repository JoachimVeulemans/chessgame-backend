using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessBackend.Data.Entities;
using ChessBackend.Services.ChessGame.Src;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new ChessGame(0, new User(), new User()).ChessBoard);
        }
    }
}