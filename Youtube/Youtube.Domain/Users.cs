using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class Users : BaseEntity
    {
        [Required, MinLength(8), MaxLength(35)]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required, MinLength(8), MaxLength(18)]
        public string Password { get; set; }

        [Required, MaxLength(300)]
        public string About { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
