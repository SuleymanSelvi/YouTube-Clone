using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.DTO;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<VideosController> _logger;

        public VideosController(IUnitOfWork unitOfWork, ILogger<VideosController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllVideos")]
        public YoutubeApiResponse<VideoDTO> GetAllVideos()
        {
            return _unitOfWork.VideosRepository.GetAllVideos();
        }

        [HttpGet(Name = "GetVideoById")]
        public YoutubeApiResponse<VideoDTO> GetVideoById(int videoId, int sessionId)
        {
            return _unitOfWork.VideosRepository.GetVideoById(videoId, sessionId);
        }

        [HttpGet(Name = "SearchVideo")]
        public YoutubeApiResponse<VideoDTO> SearchVideo(string videoName, string date, string duration, string sort)
        {
            return _unitOfWork.VideosRepository.SearchVideo(videoName, date, duration, sort);
        }

        [HttpGet(Name = "GetVideoByCategoriesId")]
        public YoutubeApiResponse<VideoDTO> GetVideoByCategoriesId(int id)
        {
            return _unitOfWork.VideosRepository.GetVideoByCategoriesId(id);
        }

        [HttpGet(Name = "GetVideoByUserId")]
        public YoutubeApiResponse<VideoDTO> GetVideoByUserId(string name)
        {
            return _unitOfWork.VideosRepository.GetVideoByUserId(name);
        }
    }
}
