using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.Models
{
    public class VideoLikeModel
    {
        public int VideoId { get; set; }
        public int UserId { get; set; }
    }
}
