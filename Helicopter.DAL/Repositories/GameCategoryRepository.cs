using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using Helicopter.DAL.Repositories.Abstraction;
using System.Text;

namespace Helicopter.DAL.Repositories
{
    class GameCategoryRepository : BaseRepository<GameCategory>, 
                                   IGameCategoryRepository
    {
        public GameCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
