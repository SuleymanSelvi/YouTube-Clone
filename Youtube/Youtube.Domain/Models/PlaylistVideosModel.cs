using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.Models
{
    public class PlaylistVideosModel
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public int PlaylistId { get; set; }
    }
}
