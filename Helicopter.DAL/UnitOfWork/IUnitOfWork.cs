using Helicopter.DAL.Entities;
using Helicopter.DAL.Repositories;
using Helicopter.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IGameCategoryRepository GameCategoryRepository { get; }
        Task CommitAsync();
    }
}
