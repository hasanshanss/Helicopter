using System;
using System.Collections.Generic;
using System.Text;

namespace Helicopter.DAL.Entities
{
    public class Game : BaseEntity
    {
        public string? GameName { get; set; }
        public string? Year { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string? DisplayName { get; set; }

        public int Views { get; set; }

        public int GameCategoryId { get; set; }
        public GameCategory? GameCategoryNavigation { get; set; }

    }
}
