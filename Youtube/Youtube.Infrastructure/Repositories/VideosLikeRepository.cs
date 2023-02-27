using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.Models;

namespace Youtube.Infrastructure.Repositories
{
    public class VideosLikeRepository : GenericRepository<VideoLike>
    {
        private YoutubeDbContext _youtubeDbContext;
        public VideosLikeRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<VideoLike> VideoLike(VideoLikeModel model)
        {
            var existLike = Get(x => x.VideoId == model.VideoId && x.UserId == model.UserId);

            if (model != null)
            {
                if (existLike == null)
                {
                    var newLike = new VideoLike
                    {
                        VideoId = model.VideoId,
                        UserId = model.UserId,
                        LikeType = 1,
                        CreatedDate = DateTime.Now
                    };

                    Add(newLike);
                    SaveChanges();

                    return new YoutubeApiResponse<VideoLike>
                    {
                        Success = true,
                        Data = newLike,
                        OptionalBoolean = true,
                        OptionalCount = _youtubeDbContext.VideoLike.Count(x => x.VideoId == model.VideoId && x.UserId == model.UserId)
                    };
                }
                else
                {
                    _youtubeDbContext.VideoLike.Remove(existLike);
                    SaveChanges();

                    return new YoutubeApiResponse<VideoLike>
                    {
                        Success = true,
                        OptionalBoolean = false,
                        OptionalCount = _youtubeDbContext.VideoLike.Count(x => x.VideoId == model.VideoId && x.UserId == model.UserId)
                    };
                }
            }
            else
            {
                return new YoutubeApiResponse<VideoLike>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }
    }
}
