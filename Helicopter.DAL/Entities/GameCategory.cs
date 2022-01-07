using System;
using System.Collections.Generic;
using System.Text;

namespace Helicopter.DAL.Entities
{
    public class GameCategory : BaseEntity
    {
        public string? CategoryName { get; set; }
        public ICollection<Game>? Game { get; set; }
    }
}
