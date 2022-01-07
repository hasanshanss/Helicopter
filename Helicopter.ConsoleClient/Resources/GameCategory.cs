using Helicopter.ConsoleClient.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAgency.ConsoleClient.Resources
{
    public class GameCategory
    {
        public string? GameName { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
