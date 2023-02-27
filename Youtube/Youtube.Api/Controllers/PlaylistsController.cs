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
    public class PlaylistsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<PlaylistsController> _logger;

        public PlaylistsController(IUnitOfWork unitOfWork, ILogger<PlaylistsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet(Name = "GetPlaylistsByUserId")]
        public YoutubeApiResponse<PlaylistsDTO> GetPlaylistsByUserId(string name = "Yırtık Pantolon")
        {
            return _unitOfWork.PlaylistsRepository.GetPlaylistsByUserId(name);
        }

        [HttpPost(Name = "NewPlaylist")]
        public YoutubeApiResponse<Playlists> NewPlaylist(PlaylistModel model)
        {
            return _unitOfWork.PlaylistsRepository.NewPlaylist(model);
        }
    }
}
