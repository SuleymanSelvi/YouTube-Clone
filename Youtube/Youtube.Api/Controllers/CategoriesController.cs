using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain;
using Youtube.Domain.DTO;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IUnitOfWork unitOfWork, ILogger<CategoriesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public YoutubeApiResponse<CategoriesDTO> GetCategories()
        {
            return _unitOfWork.CategoriesRepository.GetCategories();
        }

    }
}
