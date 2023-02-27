using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class Categories : BaseEntity
    {
        [Required,MaxLength(20)]
        public string Name { get; set; }
    }
}
