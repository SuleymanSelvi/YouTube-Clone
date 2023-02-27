using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.Models
{
    public class VideoCommentModel
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Comment { get; set; }
        public int SubCommentId { get; set; }
    }
}
