using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Data.Reposities;
using ChessBackend.Entities;
using ChessBackend.Entities.ChessGame;
using ChessBackend.Entities.Models;
using ChessBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChessBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly IChessService _chessService;
        private readonly IRepository<User> _repository;

        public ChessController(IChessService service, IRepository<User> repository)
        {
            _chessService = service;
            _repository = repository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> StartGame()
        {
            var user = await _repository.GetByIdAsync(ApplicationUtilities.GetUserIdFromHttpContext(HttpContext));

            //At the moment there is no way of inviting, so I'm using an internal dummy User as opponent
            var gameId = _chessService.StartGame(user, new Data.DataEntities.User());
            return Ok(gameId);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetMoves([FromBody] GetValidPositionsModel getValidPositionsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _repository.GetByIdAsync(ApplicationUtilities.GetUserIdFromHttpContext(HttpContext));
            return Ok(_chessService.GetPossiblePositions(user, getValidPositionsModel.GameId, getValidPositionsModel.Position));
        }

        [HttpGet]
        public IActionResult Test()
        { 
            return new OkObjectResult(Utilities.ConvertChessBoardToArrayWithPieceNames(new ChessGame(new User(), new User()).ChessBoard));
        }
    }
}