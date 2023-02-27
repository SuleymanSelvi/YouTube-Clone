using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class Subscribers : BaseEntity
    {
        [Required, ForeignKey("Users")]
        public int FollowedId { get; set; }

        [Required, ForeignKey("Users")]
        public int FollowingId { get; set; }
    }
}
