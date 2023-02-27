using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.DTO
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string VideoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public int VideoDuration { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedDateAgo { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public int VideoView { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int ChannelSubscribersCount { get; set; }
        public bool isSubscribers { get; set; }
        public bool isLike { get; set; }
        public bool isSaved { get; set; }

    }
}
