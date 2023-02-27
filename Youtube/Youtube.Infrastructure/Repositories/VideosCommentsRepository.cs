using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.DTO;
using Youtube.Domain.Models;

namespace Youtube.Infrastructure.Repositories
{
    public class VideosCommentsRepository : GenericRepository<VideoComments>
    {
        private YoutubeDbContext _youtubeDbContext;
        public VideosCommentsRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<VideoCommentDTO> GetCommentByVideoId(int videoId)
        {
            var videoComments = Find(x => x.VideoId == videoId && x.SubComment == 0).Select(x => new VideoCommentDTO
            {
                Id = x.Id,
                UserId = x.UserId,
                Comment = x.Comment,
                CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                LikeCount = _youtubeDbContext.VideoCommentsLike.Count(v => v.VideoId == x.Id && v.LikeType == 1),
                DislikeCount = _youtubeDbContext.VideoCommentsLike.Count(v => v.VideoId == x.Id && v.LikeType == 2),
                TotalCommentCount = _youtubeDbContext.VideoComments.Count(t => t.VideoId == videoId),
                //UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Name,
                //UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == x.UserId).Image,
                SubCommentId = Find(j => j.SubComment == x.Id).Select(s => new VideoCommentDTO
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    Comment = s.Comment,
                    CreatedDateAgo = Ultities.RelativeDate(s.CreatedDate),
                    LikeCount = _youtubeDbContext.VideoCommentsLike.Count(v => v.VideoId == s.Id && v.LikeType == 1),
                    DislikeCount = _youtubeDbContext.VideoCommentsLike.Count(v => v.VideoId == s.Id && v.LikeType == 2),
                    TotalCommentCount = _youtubeDbContext.VideoComments.Count(x => x.VideoId == s.Id),
                    UserName = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == s.UserId).Name,
                    UserImage = _youtubeDbContext.Users.FirstOrDefault(u => u.Id == s.UserId).Image
                }).ToList()
            }).ToList();

            return new YoutubeApiResponse<VideoCommentDTO>
            {
                Success = true,
                DataList = videoComments
            };
        }

        public YoutubeApiResponse<VideoComments> UploadComment(int userId, int videoId, string comment, int subCommentId)
        {
            var video = _youtubeDbContext.Videos.Find(videoId);

            if (video != null)
            {
                var newVideoComment = new VideoComments
                {
                    UserId = userId,
                    VideoId = videoId,
                    Comment = comment,
                    SubComment = subCommentId,
                };

                Add(newVideoComment);
                SaveChanges();

                return new YoutubeApiResponse<VideoComments>
                {
                    Success = true,
                    Data = newVideoComment,
                    OptionalCount = _youtubeDbContext.VideoComments.Count(x => x.Id == videoId)
                };
            }
            else
            {
                return new YoutubeApiResponse<VideoComments>
                {
                    Success = false,
                    ErrorMessage = "Video bulunamadı."
                };
            }
        }
    }
}
