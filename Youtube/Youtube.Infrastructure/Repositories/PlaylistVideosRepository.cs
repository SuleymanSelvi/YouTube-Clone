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
    public class PlaylistVideosRepository : GenericRepository<PlaylistVideos>
    {
        private YoutubeDbContext _youtubeDbContext;

        public PlaylistVideosRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<PlaylistVideosDTO> GetVideosByPlaylists(int playlistId)
        {
            if (playlistId != null)
            {
                var playlistVideos = (from p in _youtubeDbContext.Playlists
                                      join pv in _youtubeDbContext.PlaylistVideos
                                      on p.Id equals pv.PlaylistId
                                      join v in _youtubeDbContext.Videos
                                      on pv.VideoId equals v.Id
                                      join u in _youtubeDbContext.Users
                                      on p.UserId equals u.Id
                                      where p.Id == playlistId
                                      select new PlaylistVideosDTO
                                      {
                                          Id = v.Id,
                                          VideoPath = v.VideoPath,
                                          ThumbnailPath = v.ThumbnailPath,
                                          VideoDuration = v.VideoDuration,
                                          Description = v.Description,
                                          CreatedDateAgo = Ultities.RelativeDate(v.CreatedDate),
                                          PlaylistName = p.Name,
                                          ChannelName = u.Name,
                                          PlaylistVideoCount = _youtubeDbContext.PlaylistVideos.Count(x=> x.PlaylistId == p.Id)
                                      }).ToList();

                return new YoutubeApiResponse<PlaylistVideosDTO>
                {
                    Success = true,
                    DataList = playlistVideos
                };
            }
            else
            {
                return new YoutubeApiResponse<PlaylistVideosDTO>
                {
                    Success = false,
                    Message = "Boş Alan"
                };
            }

        }

        public YoutubeApiResponse<PlaylistVideos> NewPlaylistVideo(PlaylistVideosModel model)
        {
            var existsPlaylist = _youtubeDbContext.Playlists.FirstOrDefault(x => x.Id == model.PlaylistId);

            if (existsPlaylist != null)
            {
                var newPlaylistVideo = new PlaylistVideos
                {
                    UserId = model.UserId,
                    VideoId = model.VideoId,
                    PlaylistId = model.PlaylistId,
                    CreatedDate = DateTime.Now
                };

                Add(newPlaylistVideo);
                SaveChanges();

                return new YoutubeApiResponse<PlaylistVideos>
                {
                    Success = true,
                    Data = newPlaylistVideo
                };
            }
            else
            {
                return new YoutubeApiResponse<PlaylistVideos>
                {
                    Success = false,
                    ErrorMessage = "Boş alan"
                };
            }
        }
    }
}
