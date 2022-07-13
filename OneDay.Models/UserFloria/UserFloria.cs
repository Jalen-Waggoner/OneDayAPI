using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneDay.Models.UserFloria
{
    public class UserFloria
    {
        [Required]
        [MinLength(4)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(4)]
        public string Content { get; set; } = null!;
    }
}