using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;

namespace Youtube.Infrastructure.Repositories
{
    public class VideosCommentsLikeRepository : GenericRepository<VideoCommentsLike>
    {
        private YoutubeDbContext _youtubeDbContext;
        public VideosCommentsLikeRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }
    }
}
