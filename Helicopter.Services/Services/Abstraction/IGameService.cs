using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Helicopter.DAL.Entities;

namespace Helicopter.Services.Abstraction
{
    public interface IGameService<TEntity, KEntity> where TEntity : Game, new()
                                                    where KEntity : GameCategory, new()

    {
        //Delete
        Task DeleteGameAsync(int id, byte[] timeStamp);
        Task DeleteGameAsync(IEnumerable<TEntity> entities);

        //Get
        Task<TEntity> GetOneGameAsync(int id);
        IEnumerable<TEntity> GetGameBy(int? GameCategoryId = null,
                                        Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        bool isDeleted = false);

        IEnumerable<TEntity> GetGameList(int? GameCategoryId = null);

        Task<KEntity> GetGameCategoryAsync(int GameId);

        Task<int> GetCountAsync();
        TEntity GetMostViewed();

        //Insert&Update
        Task AddGameAsync(TEntity entity);
        Task AddGameAsync(IEnumerable<TEntity> entityList);
        Task UpdateGameAsync(TEntity entityToUpdate);
        Task UpdateGameAsync(IEnumerable<TEntity> entityList);

    }
}
