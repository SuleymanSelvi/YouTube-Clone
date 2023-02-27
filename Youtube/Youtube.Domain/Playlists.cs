using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class Playlists : BaseEntity
    {
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
