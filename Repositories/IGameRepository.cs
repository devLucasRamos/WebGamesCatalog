using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGamesCatalog.Entities;

namespace WebGamesCatalog.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Get(int page, int quantity);

        Task<List<Game>> GetByName(string name, string prod);

        Task<Game> GetByGuid(Guid id);

        Task InsertGame(Game game);

        Task GameAtt(Game game);

        Task EraseGame(Guid id);
    }
}
