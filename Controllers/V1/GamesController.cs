using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebGamesCatalog.Excepctions;
using WebGamesCatalog.InputModel;
using WebGamesCatalog.Services;
using WebGamesCatalog.ViewModel;

namespace WebGamesCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get([FromQuery,Range(1,int.MaxValue)] int page = 1, [FromQuery, Range(1,50)] int quantity = 5)
        {
            var games = await _gameService.Get(page,quantity);

            if (games.Count == 0)
                return NoContent();

            return Ok(games);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<List<GameViewModel>>> GetByGuid([FromRoute] Guid idGame)
        {
            var game = await _gameService.GetByGuid(idGame);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InsertGame([FromBody]GameInputModel gameInputModel)
        {
            try
            {
                var game = await _gameService.InsertGame(gameInputModel);

                return Ok(game);
            }
            catch (GameExistException)
            {
                throw new GameExistException();
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> GameAtt([FromRoute] Guid idGame, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.GameAtt(idGame, gameInputModel);

                return Ok();
            }
            catch (GameNoExistException)
            {
                throw new GameNoExistException();
            }
        }


        [HttpPatch("{idGame:guid}/price/{price:double}")]
        public async Task<ActionResult> GamePriceAtt([FromRoute] Guid idGame, [FromRoute] double price)
        {
            try
            {
                await _gameService.GamePriceAtt(idGame, price);

                return Ok();
            }
            catch (GameNoExistException)
            {
                throw new GameNoExistException();
            }
        }
        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> EraseGame([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.EraseGame(idGame);

                return Ok(idGame);
            }

            catch (GameNoExistException)
            {
                throw new GameNoExistException();
            }
        }
    }
}
