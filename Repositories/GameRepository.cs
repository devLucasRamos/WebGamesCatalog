using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGamesCatalog.Entities;

namespace WebGamesCatalog.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static readonly Dictionary<Guid, Game> games = new()
        {
            {Guid.Parse("e7dae283-53d0-4bb6-a56c-12c3dc9e61ac"),new Game{Id = Guid.Parse("e7dae283-53d0-4bb6-a56c-12c3dc9e61ac"), Name = "Final Fantasy XV", Prod = "Square Enix", Price = 230.49 } },
            {Guid.Parse("6543b8ac-d43c-4d97-81c2-3079b04dddb7"),new Game{Id = Guid.Parse("6543b8ac-d43c-4d97-81c2-3079b04dddb7"), Name = "Final Fantasy XIV", Prod = "Square Enix", Price = 218.29 } },
            {Guid.Parse("103ed951-7f13-40ee-901c-c940e773d4ab"),new Game{Id = Guid.Parse("103ed951-7f13-40ee-901c-c940e773d4ab"), Name = "Lightning Returns: Final Fantasy XIII", Prod = "Square Enix", Price = 257.99 } },
            {Guid.Parse("b79fd51f-d356-4d5d-b736-251f2e6af9a5"),new Game{Id = Guid.Parse("b79fd51f-d356-4d5d-b736-251f2e6af9a5"), Name = "Final Fantasy XIII part 2", Prod = "Square Enix", Price = 235.00 } },
            {Guid.Parse("561a30fd-e691-4201-a400-f62d42d8e1f0"),new Game{Id = Guid.Parse("561a30fd-e691-4201-a400-f62d42d8e1f0"), Name = "Final Fantasy XIII", Prod = "Square Enix", Price = 195.19 } },
            {Guid.Parse("3eca4861-7745-43ae-b313-6b9979f74289"),new Game{Id = Guid.Parse("3eca4861-7745-43ae-b313-6b9979f74289"), Name = "Final Fantasy XII", Prod = "Square Enix", Price = 187.99 } },
            {Guid.Parse("54b31a73-61c2-424a-ab06-cfa1eaa91d28"),new Game{Id = Guid.Parse("54b31a73-61c2-424a-ab06-cfa1eaa91d28"), Name = "Final Fantasy XI", Prod = "Square Enix", Price = 155.79 } },
            {Guid.Parse("3b93c5eb-7c59-4446-b8df-f09254faacc6"),new Game{Id = Guid.Parse("3b93c5eb-7c59-4446-b8df-f09254faacc6"), Name = "Final Fantasy X", Prod = "Square Enix", Price = 142.89 } },
        };

        public Task<List<Game>> Get(int page, int quantity)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Game> GetByGuid(Guid id)
        {
            if (!games.ContainsKey(id))
                return null;

            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> GetByName(string name, string prod)
        {
            return Task.FromResult(games.Values.Where(game => game.Name.Equals(name) && game.Prod.Equals(prod)).ToList());
        }

        public Task InsertGame(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task GameAtt(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }
        public Task EraseGame(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose() { }

    }
}
