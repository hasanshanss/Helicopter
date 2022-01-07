using Microsoft.EntityFrameworkCore;
using Helicopter.DAL.Entities;
using Helicopter.DAL.UnitOfWork;
using Helicopter.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Helicopter.Services
{
    public class GameService : IGameService<Game, GameCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddGameAsync(Game entity)
        {
            await _unitOfWork.GameRepository.InsertAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddGameAsync(IEnumerable<Game> entityList)
        {
            await _unitOfWork.GameRepository.InsertRangeAsync(entityList);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGameAsync(int id, byte[] timeStamp)
        {
            _unitOfWork.GameRepository.Delete(id, timeStamp);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGameAsync(IEnumerable<Game> entities)
        {
            _unitOfWork.GameRepository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetCountAsync() => await _unitOfWork.GameRepository.GetCountAsync();

        public Game GetMostViewed() => _unitOfWork.GameRepository.GetMostViewed();

        public IEnumerable<Game> GetGameBy(int? GameCategoryId = null, Expression<Func<Game, bool>> filter = null, Func<IQueryable<Game>, IOrderedQueryable<Game>> orderBy = null, bool isDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task<GameCategory> GetGameCategoryAsync(int GameId) => await _unitOfWork.GameRepository.GetGameCategoryAsync(GameId);

        public IEnumerable<Game> GetGameList(int? GameCategoryId = null) => _unitOfWork.GameRepository.GetGameByCategoryId(GameCategoryId);

        public async Task<Game> GetOneGameAsync(int id) => await _unitOfWork.GameRepository.FindAsNoTrackingAsync(id);

        public async Task UpdateGameAsync(Game entityToUpdate)
        {
            _unitOfWork.GameRepository.Update(entityToUpdate);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateGameAsync(IEnumerable<Game> entityList)
        {
            _unitOfWork.GameRepository.UpdateRange(entityList);
            await _unitOfWork.CommitAsync();
        }
    }
}
