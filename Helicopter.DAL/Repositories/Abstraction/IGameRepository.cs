using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter.DAL.Repositories.Abstraction
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<GameCategory?> GetGameCategoryAsync(int gameId);
        Game GetMostViewed();
        Task<int> GetViewCountAsync(int gameId);

        IEnumerable<Game> GetGameByCategoryId(int? categoryId = null);
        
    }
}
