using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.Models;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoViewController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<VideoViewController> _logger;

        public VideoViewController(IUnitOfWork unitOfWork, ILogger<VideoViewController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost(Name = "VideoView")]
        public YoutubeApiResponse<VideoView> VideoView(VideoViewModel model)
        {
            return _unitOfWork.VideosViewRepository.VideoView(model);
        }
    }
}
