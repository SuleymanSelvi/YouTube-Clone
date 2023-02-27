using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class VideoComments : BaseEntity
    {
        [Required, ForeignKey("Users")]
        public int UserId { get; set; }

        [Required, ForeignKey("Videos")]
        public int VideoId { get; set; }

        [Required, MaxLength(400)]
        public string Comment { get; set; }

        [MaxLength(400)]
        public int SubComment { get; set; }
    }
}
