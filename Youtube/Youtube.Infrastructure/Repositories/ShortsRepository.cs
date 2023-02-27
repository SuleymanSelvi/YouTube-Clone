using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;

namespace Youtube.Infrastructure.Repositories
{
    public class ShortsRepository : GenericRepository<Shorts>
    {
        private YoutubeDbContext _youtubeDbContext;
        public ShortsRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }
    }
}
