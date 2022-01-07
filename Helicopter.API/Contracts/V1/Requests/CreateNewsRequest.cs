using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helicopter.API.Contracts.V1.Requests
{
    public class CreateGameRequest
    {
        [Required]
        [StringLength(50)]
        public string? GameName { get; set; }

        [Required]
        [StringLength(4)]
        public string? Year { get; set; }

        [Required]
        public int GameCategoryId { get; set; }
    }
}
