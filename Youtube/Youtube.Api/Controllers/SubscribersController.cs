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
    public class SubscribersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<SubscribersController> _logger;

        public SubscribersController(IUnitOfWork unitOfWork, ILogger<SubscribersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost(Name = "NewSubscribers")]
        public YoutubeApiResponse<Subscribers> NewSubscribers(SubscribersModel model)
        {
            return _unitOfWork.SubscribersRepository.NewSubscribers(model);
        }

        [HttpGet(Name = "GetUserSubscribers")]
        public YoutubeApiResponse<UserDTO> GetUserSubscribers(int id)
        {
            return _unitOfWork.SubscribersRepository.GetUserSubscribers(id);
        }
    }
}
