using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGamesCatalog.InputModel;
using WebGamesCatalog.ViewModel;

namespace WebGamesCatalog.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> Get(int page, int quantity);

        Task<GameViewModel> GetByGuid(Guid id);

        Task<GameViewModel> InsertGame(GameInputModel game);

        Task GameAtt(Guid id, GameInputModel game);

        Task GamePriceAtt(Guid id, double price);

        Task EraseGame(Guid id);
    }
}
