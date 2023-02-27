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
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost(Name = "Registir")]
        public YoutubeApiResponse<Users> Registir(RegistirModel model)
        {
            return _unitOfWork.UsersRepository.Registir(model);
        }

        [HttpPost(Name = "Login")]
        public YoutubeApiResponse<Users> Login(LoginModel model)
        {
            return _unitOfWork.UsersRepository.Login(model);
        }

        [HttpGet(Name = "GetUserDetail")]
        public YoutubeApiResponse<UserDTO> GetUserDetail(string name, int sessionId)
        {
            return _unitOfWork.UsersRepository.GetUserDetail(name, sessionId);
        }
    }
}
