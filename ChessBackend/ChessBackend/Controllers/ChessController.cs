using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Data.Reposities;
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
        private readonly IRepository<User> _repository;

        public ChessController(IChessService service, IRepository<User> repository)
        {
            _service = service;
            _repository = repository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> StartGame()
        {
            var userId = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(p => p.Value).FirstOrDefault();
            var user = await _repository.GetById(userId);
            var users = await _repository.GetAll();
            var user2 = users[0];

            var result = _service.StartGame(user, user2);

            var chessGame = _service.GetChessGame(user, result);
            chessGame.Move(new Move()
            {
                From = "e2",
                To = "e3"
            });

            return new OkObjectResult(Utilities.ConvertChessBoardToArrayWithPieceNames(chessGame.ChessBoard));
        }

        [HttpGet]
        public IActionResult Get()
        { 
            return new OkObjectResult(Utilities.ConvertChessBoardToArrayWithPieceNames(new ChessGame(new User(), new User()).ChessBoard));
        }
    }
}