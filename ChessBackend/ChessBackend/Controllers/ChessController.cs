using ChessBackend.Data.DataEntities;
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

            return new OkObjectResult(Utilities.ConvertChessBoardToArrayWithPieceNames(new ChessGame(0, new User(), new User()).ChessBoard));
        }
    }
}