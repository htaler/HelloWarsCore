using HelloWars.ArenaServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelloWars.ArenaServer.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public void PlayDuel()
        {
            _gameService.PlayDuelAsync();
        }
    }
}
