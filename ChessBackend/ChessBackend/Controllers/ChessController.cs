using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Entities.ChessGame;
using ChessBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChessBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly IChessService _service;

        public ChessController(IChessService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult StartGame()
        {
            var x = this.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(p => p.Value).FirstOrDefault();

            return Ok("");
        }

        [HttpGet]
        public IActionResult Get()
        { 
            return new OkObjectResult(Utilities.ConvertChessBoardToArrayWithPieceNames(new ChessGame(0, new User(), new User()).ChessBoard));
        }
    }
}