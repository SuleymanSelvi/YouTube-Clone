using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.DTO
{
    public class PlaylistVideosDTO
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
        public string PlaylistName { get; set; }
        public string ChannelName { get; set; }
        public int PlaylistVideoCount { get; set; }
    }
}
