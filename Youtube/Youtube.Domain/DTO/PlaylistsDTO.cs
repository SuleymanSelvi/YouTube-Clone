using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.DTO
{
    public class PlaylistsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public int Count { get; set; }
        public int FirstVideoIdInPlaylist { get; set; }
        public string FirstVideoIdThumbail { get; set; }
    }
}
