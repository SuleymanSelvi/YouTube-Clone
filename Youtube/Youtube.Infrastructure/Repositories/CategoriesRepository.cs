using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.DTO;

namespace Youtube.Infrastructure.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>
    {
        private YoutubeDbContext _youtubeDbContext;
        public CategoriesRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<CategoriesDTO> GetCategories()
        {
            var categories = All().Select(x => new CategoriesDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return new YoutubeApiResponse<CategoriesDTO>
            {
                Success = true,
                DataList = categories
            };
        }
    }
}
