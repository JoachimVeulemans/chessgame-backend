using ChessBackend.Entities;
using ChessBackend.Entities.ChessGame;
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