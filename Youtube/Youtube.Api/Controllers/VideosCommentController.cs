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
    public class VideosCommentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<VideosCommentController> _logger;

        public VideosCommentController(IUnitOfWork unitOfWork, ILogger<VideosCommentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet(Name = "GetCommentByVideoId")]
        public YoutubeApiResponse<VideoCommentDTO> GetCommentByVideoId(int videoId)
        {
            return _unitOfWork.VideosCommentsRepository.GetCommentByVideoId(videoId);
        }

        [HttpPost(Name = "UploadComment")]
        public YoutubeApiResponse<VideoComments> UploadComment(VideoCommentModel model)
        {
            return _unitOfWork.VideosCommentsRepository.UploadComment(model.UserId, model.VideoId, model.Comment, model.SubCommentId);
        }
    }
}
