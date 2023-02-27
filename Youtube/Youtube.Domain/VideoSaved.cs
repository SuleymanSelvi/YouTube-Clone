using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class VideoSaved : BaseEntity
    {
        [Required,ForeignKey("Videos")]
        public int VideoId { get; set; }

        [Required,ForeignKey("Users")]
        public int UserId { get; set; }
    }
}
