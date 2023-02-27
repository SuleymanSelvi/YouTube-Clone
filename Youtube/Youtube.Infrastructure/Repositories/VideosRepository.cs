using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.DTO;

namespace Youtube.Infrastructure.Repositories
{
    public class VideosRepository : GenericRepository<Videos>
    {
        private YoutubeDbContext _youtubeDbContext;

        public VideosRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<VideoDTO> GetAllVideos()
        {
            Random random = new Random();

            var videos = All().Select(x => new VideoDTO
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                UserId = x.UserId,
                VideoPath = x.VideoPath,
                ThumbnailPath = x.ThumbnailPath,
                VideoDuration = x.VideoDuration,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                VideoView = _youtubeDbContext.VideoView.Count(v => v.VideoId == x.Id)
            }).OrderBy(x => random.Next()).ToList();

            return new YoutubeApiResponse<VideoDTO>
            {
                Success = true,
                DataList = videos
            };
        }

        public YoutubeApiResponse<VideoDTO> GetVideoById(int videoId, int sessionId)
        {

            if (videoId != null)
            {
                var video = Find(x => x.Id == videoId).Select(x => new VideoDTO
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    UserId = x.UserId,
                    VideoPath = x.VideoPath,
                    ThumbnailPath = x.ThumbnailPath,
                    VideoDuration = x.VideoDuration,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                    UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                    UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                    VideoView = _youtubeDbContext.VideoView.Count(v => v.VideoId == x.Id),
                    LikeCount = _youtubeDbContext.VideoLike.Count(v => v.VideoId == x.Id && v.LikeType == 1),
                    DislikeCount = _youtubeDbContext.VideoLike.Count(v => v.VideoId == x.Id && v.LikeType == 2),
                    ChannelSubscribersCount = _youtubeDbContext.Subscribers.Count(s => s.FollowedId == x.UserId),
                    isSubscribers = _youtubeDbContext.Subscribers.Any(s => s.FollowedId == x.UserId && s.FollowingId == sessionId),
                    isLike = _youtubeDbContext.VideoLike.Any(s => s.VideoId == x.Id && s.UserId == sessionId),
                    isSaved = _youtubeDbContext.VideoSaved.Any(s => s.VideoId == x.Id && s.UserId == sessionId),
                }).FirstOrDefault();

                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = true,
                    Data = video
                };
            }
            else
            {
                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = false,
                    ErrorMessage = "Video bulunamadı"
                };
            }
        }

        public YoutubeApiResponse<VideoDTO> GetVideoByCategoriesId(int id)
        {
            Random random = new Random();

            if (id != null)
            {
                var videos = Find(x => x.CategoryId == id).Select(x => new VideoDTO
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    UserId = x.UserId,
                    VideoPath = x.VideoPath,
                    ThumbnailPath = x.ThumbnailPath,
                    VideoDuration = x.VideoDuration,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                    UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                    UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                    VideoView = _youtubeDbContext.VideoView.Count(v => v.VideoId == x.Id)
                }).OrderBy(x => random.Next()).ToList();

                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = true,
                    DataList = videos
                };
            }
            else
            {
                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }

        public YoutubeApiResponse<VideoDTO> GetVideoByUserId(string name)
        {
            Random random = new Random();

            if (name != null)
            {
                var userId = _youtubeDbContext.Users.FirstOrDefault(x => x.Name == "Yırtık Pantolon").Id;

                var userVideos = Find(x => x.UserId == userId).Select(x => new VideoDTO
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    VideoPath = x.VideoPath,
                    ThumbnailPath = x.ThumbnailPath,
                    VideoDuration = x.VideoDuration,
                    Description = x.Description,
                    CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                    UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                    UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                    VideoView = _youtubeDbContext.VideoView.Count(v => v.VideoId == x.Id),
                    LikeCount = _youtubeDbContext.VideoLike.Count(v => v.VideoId == x.Id && v.LikeType == 1)
                }).OrderBy(x => random.Next()).ToList();

                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = true,
                    DataList = userVideos
                };
            }
            else
            {
                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }

        }

        public YoutubeApiResponse<VideoDTO> SearchVideo(string videoName, string date = "default", string duration = "default", string sort = "default")
        {
            Random random = new Random();

            var now = DateTime.Now;
            var today = DateTime.Today;
            var week = DateTime.Today.AddDays(-7);
            var month = DateTime.Today.AddMonths(-1);
            var year = DateTime.Today.AddYears(-1);

            if (videoName != null)
            {
                var videos = Find(x => (x.Description.StartsWith(videoName) || x.Description.Contains(videoName))
                &&
                (duration == "max4" ? x.VideoDuration < 1000 :
                duration == "between" ? x.VideoDuration > 1000 && x.VideoDuration < 2500 :
                duration == "min20" ? x.VideoDuration > 2500 && x.VideoDuration < 4000 :
                x.VideoDuration > 0)
                &&
                (date == "today" ? x.CreatedDate == today :
                date == "week" ? x.CreatedDate > week && x.CreatedDate < today :
                date == "month" ? x.CreatedDate > month && x.CreatedDate < today :
                date == "year" ? x.CreatedDate > year && x.CreatedDate < today :
                x.CreatedDate < now)
                ).Select(x => new VideoDTO
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    UserId = x.UserId,
                    VideoPath = x.VideoPath,
                    ThumbnailPath = x.ThumbnailPath,
                    VideoDuration = x.VideoDuration,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                    UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                    UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                    VideoView = _youtubeDbContext.VideoView.Count(v => v.VideoId == x.Id),
                    LikeCount = _youtubeDbContext.VideoLike.Count(v => v.VideoId == x.Id && v.LikeType == 1),
                    DislikeCount = _youtubeDbContext.VideoLike.Count(v => v.VideoId == x.Id && v.LikeType == 2),
                    ChannelSubscribersCount = _youtubeDbContext.Subscribers.Count(s => s.FollowedId == x.UserId)
                }).OrderByDescending(x => sort == "view" ? x.VideoView : sort == "rating" ? x.LikeCount : random.Next()).ToList();

                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = true,
                    DataList = videos
                };
            }
            else
            {
                return new YoutubeApiResponse<VideoDTO>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }
    }
}
