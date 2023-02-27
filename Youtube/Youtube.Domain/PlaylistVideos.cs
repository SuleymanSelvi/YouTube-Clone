using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class PlaylistVideos : BaseEntity
    {
        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Videos")]
        public int VideoId { get; set; }

        [ForeignKey("Playlists")]
        public int PlaylistId { get; set; }
    }
}
