using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.Models;

namespace Youtube.Infrastructure.Repositories
{
    public class VideosViewRepository : GenericRepository<VideoView>
    {
        private YoutubeDbContext _youtubeDbContext;
        public VideosViewRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<VideoView> VideoView(VideoViewModel model)
        {
            var existDayWatched = Get(x => x.VideoId == model.VideoId && x.UserId == model.UserId/* && x.CreatedDate != DateTime.Now*/);

            if (model != null)
            {
                //if(existDayWatched == null)
                //{
                    var newView = new VideoView
                    {
                        VideoId = model.VideoId,
                        UserId = model.UserId,
                        CreatedDate = DateTime.Now
                    };

                    Add(newView);
                    SaveChanges();

                    return new YoutubeApiResponse<VideoView>
                    {
                        Success = true,
                        OptionalCount = _youtubeDbContext.VideoView.Count(x => x.VideoId == model.VideoId)
                    };
                //}
                //else
                //{
                //    return new YoutubeApiResponse<VideoView>
                //    {
                //        Success = false,
                //        Message = "Kullanıcı bu videoyu geçtiğimiz 1 gün içinde izledi"
                //    };
                //}
              
            }
            else
            {
                return new YoutubeApiResponse<VideoView>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }
    }
}
