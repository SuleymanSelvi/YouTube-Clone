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
    public class PlaylistsRepository : GenericRepository<Playlists>
    {
        private YoutubeDbContext _youtubeDbContext;

        public PlaylistsRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<PlaylistsDTO> GetPlaylistsByUserId(string name)
        {
            var user = _youtubeDbContext.Users.FirstOrDefault(x => x.Name == name);

            if (user != null)
            {
                var video = _youtubeDbContext.Videos.Where(x => x.UserId == user.Id).Select(x => x.Id).ToList();
                var firstVideoIdInPlaylist = _youtubeDbContext.PlaylistVideos.First(x => video.Contains(x.VideoId));

                var playlists = Find(x => x.UserId == user.Id).Select(x => new PlaylistsDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserId = x.UserId,
                    CreatedDate = x.CreatedDate,
                    Count = _youtubeDbContext.PlaylistVideos.Count(p => p.PlaylistId == x.Id),
                    FirstVideoIdInPlaylist = firstVideoIdInPlaylist.VideoId,
                    FirstVideoIdThumbail = _youtubeDbContext.Videos.FirstOrDefault(x => x.Id == firstVideoIdInPlaylist.VideoId).ThumbnailPath,
                }).ToList();

                return new YoutubeApiResponse<PlaylistsDTO>
                {
                    Success = true,
                    DataList = playlists
                };
            }
            else
            {
                return new YoutubeApiResponse<PlaylistsDTO>
                {
                    Success = false,
                    ErrorMessage = "Kullanıcı bulunamadı"
                };
            }
        }

        public YoutubeApiResponse<Playlists> NewPlaylist(PlaylistModel model)
        {
            if (model != null)
            {
                var newPlaylist = new Playlists
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    CreatedDate = DateTime.Now
                };

                Add(newPlaylist);
                SaveChanges();

                return new YoutubeApiResponse<Playlists>
                {
                    Success = true,
                    Data = newPlaylist
                };
            }
            else
            {
                return new YoutubeApiResponse<Playlists>
                {
                    Success = false,
                    ErrorMessage = "Boş Alan"
                };
            }
        }
    }
}
