using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using Helicopter.DAL.Repositories.Abstraction;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Helicopter.DAL.Repositories
{
    class GameRepository : BaseRepository<Game>, 
                           IGameRepository
    {
      
        public GameRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public Game GetMostViewed()
        {
            return dbSet.Aggregate((game1, game2) => game1.Views > game2.Views ? game1 : game2);
        }

        public IEnumerable<Game> GetGameByCategoryId(int? categoryId = null)
        {
            IQueryable<Game> query = dbSet.AsNoTracking();

            if (categoryId.HasValue)
                query = query.Where(m => m.GameCategoryId == categoryId);

            return  query;
        }

        public async Task<GameCategory?> GetGameCategoryAsync(int gameId)
        {
            return await dbSet
                            .Where(m => m.Id == gameId)
                            .Select(m=>m.GameCategoryNavigation)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> GetViewCountAsync(int gameId)
        {
            return await dbSet
                            .Where(m => m.Id == gameId)
                            .Select(m => m.Views)
                            .FirstOrDefaultAsync();
        }
    }
}
