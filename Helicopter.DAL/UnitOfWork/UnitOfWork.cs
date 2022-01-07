using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Helicopter.DAL.Entities;
using Helicopter.DAL.Repositories;
using Helicopter.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private IGameRepository _game;
        private IGameCategoryRepository _gameCategories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGameRepository GameRepository
        {
            get
            {
                return _game ?? (_game = new GameRepository(_dbContext));
            }
        }

        public IGameCategoryRepository GameCategoryRepository
        {
            get
            {
                return _gameCategories ?? (_gameCategories = new GameCategoryRepository(_dbContext));
            }
        }

     

        public async Task CommitAsync()
        {
            try
            {
                HandleSoftDelete();

                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void HandleSoftDelete()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {

                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
