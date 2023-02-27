using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.Models;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoLikeController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<VideoLikeController> _logger;

        public VideoLikeController(IUnitOfWork unitOfWork, ILogger<VideoLikeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost(Name = "VideoLike")]
        public YoutubeApiResponse<VideoLike> VideoLike(VideoLikeModel model)
        {
            return _unitOfWork.VideosLikeRepository.VideoLike(model);
        }
    }
}
