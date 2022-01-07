using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter.Services.Abstraction
{
    public interface IGameCategoryService<TEntity> where TEntity : GameCategory, new()
                                             


    {
        //Delete
        Task DeleteGameCategoryAsync(int id, byte[] timeStamp);
        Task DeleteGameCategoryAsync(IEnumerable<TEntity> entities);

        //Get
        Task<TEntity> GetOneGameCategoryAsync(int id);

        IAsyncEnumerable<TEntity> GetGameCategoryListAsync();
        IAsyncEnumerable<TEntity> GetDeletedGameCategoryListAsync();

        Task<int> GetCountAsync();

        //Insert&Update
        Task AddGameCategoryAsync(TEntity entity);
        Task AddGameCategoryAsync(IEnumerable<TEntity> entityList);
        Task UpdateGameCategoryAsync(TEntity entityToUpdate);
        Task UpdateGameCategoryAsync(IEnumerable<TEntity> entityList);

    }
}
