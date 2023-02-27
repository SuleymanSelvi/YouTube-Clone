using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.Models;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoSavedController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<VideoSavedController> _logger;

        public VideoSavedController(IUnitOfWork unitOfWork, ILogger<VideoSavedController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost(Name = "VideoSaved")]
        public YoutubeApiResponse<VideoSaved> VideoSaved(VideoSavedModel model)
        {
            return _unitOfWork.VideoSavedRepository.VideoSaved(model);
        }
    }
}
