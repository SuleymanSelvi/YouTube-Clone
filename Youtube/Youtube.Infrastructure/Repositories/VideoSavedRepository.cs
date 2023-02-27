using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.Models;

namespace Youtube.Infrastructure.Repositories
{
    public class VideoSavedRepository : GenericRepository<VideoSaved>
    {
        private YoutubeDbContext _youtubeDbContext;
        public VideoSavedRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<VideoSaved> VideoSaved(VideoSavedModel model)
        {
            if (model != null)
            {
                var existSave = Get(x => x.VideoId == model.VideoId && x.UserId == model.UserId);

                if (existSave == null)
                {
                    var newSave = new VideoSaved
                    {
                        VideoId = model.VideoId,
                        UserId = model.UserId,
                        CreatedDate = DateTime.Now
                    };

                    Add(newSave);
                    SaveChanges();

                    return new YoutubeApiResponse<VideoSaved>
                    {
                        Success = true,
                        Data = newSave,
                        OptionalBoolean = true
                    };
                }
                else
                {
                    _youtubeDbContext.VideoSaved.Remove(existSave);
                    SaveChanges();

                    return new YoutubeApiResponse<VideoSaved>
                    {
                        Success = true,
                        OptionalBoolean = false
                    };
                }

            }
            else
            {
                return new YoutubeApiResponse<VideoSaved>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }
    }
}
