using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGamesCatalog.Entities;
using WebGamesCatalog.Excepctions;
using WebGamesCatalog.InputModel;
using WebGamesCatalog.Repositories;
using WebGamesCatalog.ViewModel;

namespace WebGamesCatalog.Services
{
    public class GameService : IGameService
    {
        public readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> Get(int page, int quantity)
        {
            var games = await _gameRepository.Get(page, quantity);

            return games.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Prod = game.Prod,
                Price = game.Price
            }).ToList();
        }
        public async Task<List<GameViewModel>> GetByName(string name, string prod)
        {
            var names = await _gameRepository.GetByName(name, prod);

            return names.Select(name => new GameViewModel
            {
                Id = name.Id,
                Name = name.Name,
                Prod = name.Prod,
                Price = name.Price
            }).ToList();
        }

        public async Task<GameViewModel> GetByGuid(Guid idGame)
        {
            var game = await _gameRepository.GetByGuid(idGame);

            if (game == null)
                return null;

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Prod = game.Prod,
                Price = game.Price
            };
        }

        public async Task<GameViewModel> InsertGame(GameInputModel game)
        {

            var gameEntity = await _gameRepository.GetByName(game.Name,game.Prod);

            if (gameEntity.Count > 0)
                throw new GameNoExistException();

            var newgame = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Prod = game.Prod,
                Price = game.Price
            };

            await _gameRepository.InsertGame(newgame);

            return new GameViewModel
            {
                Id = newgame.Id,
                Name = newgame.Name,
                Prod = newgame.Prod,
                Price = game.Price
            };
        }

        public async Task GameAtt(Guid id, GameInputModel game)
        {
            var gameEntity = await _gameRepository.GetByGuid(id);

            if (gameEntity == null)
                throw new GameNoExistException();

            gameEntity.Name = game.Name;
            gameEntity.Prod = game.Prod;
            gameEntity.Price = game.Price;

            await _gameRepository.GameAtt(gameEntity);
        }
        public async Task GamePriceAtt(Guid id, double price)
        {
            var gameEntity = await _gameRepository.GetByGuid(id);

            if (gameEntity == null)
                throw new GameNoExistException();

            gameEntity.Price = price;

            await _gameRepository.GameAtt(gameEntity);
        }

        public async Task EraseGame(Guid id)
        {
            var gameEntity = await _gameRepository.GetByGuid(id);

            if (gameEntity == null)
                throw new GameNoExistException();

            await _gameRepository.GameAtt(gameEntity);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }
    }
}
