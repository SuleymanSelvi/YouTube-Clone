using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.DTO
{
    public class VideoCommentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public string CreatedDateAgo { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int TotalCommentCount { get; set; }
        public List<VideoCommentDTO> SubCommentId { get; set; }
    }
}
