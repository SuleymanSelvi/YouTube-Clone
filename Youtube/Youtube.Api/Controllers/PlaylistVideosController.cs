using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.DTO;
using Youtube.Domain.Models;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlaylistVideosController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<PlaylistVideosController> _logger;

        public PlaylistVideosController(IUnitOfWork unitOfWork, ILogger<PlaylistVideosController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet(Name = "GetVideosByPlaylists")]
        public YoutubeApiResponse<PlaylistVideosDTO> GetVideosByPlaylists(int playlistId)
        {
            return _unitOfWork.PlaylistVideosRepository.GetVideosByPlaylists(playlistId);
        }

        [HttpPost(Name = "NewPlaylistVideo")]
        public YoutubeApiResponse<PlaylistVideos> NewPlaylistVideo(PlaylistVideosModel model)
        {
            return _unitOfWork.PlaylistVideosRepository.NewPlaylistVideo(model);
        }
    }
}
