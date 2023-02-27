using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;
using Youtube.Domain.DTO;
using Youtube.Domain.Models;

namespace Youtube.Infrastructure.Repositories
{
    public class SubscribersRepository : GenericRepository<Subscribers>
    {
        private YoutubeDbContext _youtubeDbContext;
        public SubscribersRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<Subscribers> NewSubscribers(SubscribersModel model)
        {
            var exitsSubscribers = Get(x => x.FollowedId == model.FollowedId && x.FollowingId == model.FollowingId);

            if (model != null)
            {
                if (exitsSubscribers == null)
                {
                    var newSubscribers = new Subscribers
                    {
                        FollowedId = model.FollowedId,
                        FollowingId = model.FollowingId,
                        CreatedDate = DateTime.Now
                    };

                    Add(newSubscribers);
                    SaveChanges();

                    return new YoutubeApiResponse<Subscribers>
                    {
                        Success = true,
                        Data = newSubscribers,
                        OptionalBoolean = true,
                        OptionalCount = _youtubeDbContext.Subscribers.Count(x => x.FollowedId == model.FollowedId)
                    };
                }
                else
                {
                    _youtubeDbContext.Subscribers.Remove(exitsSubscribers);
                    SaveChanges();

                    return new YoutubeApiResponse<Subscribers>
                    {
                        Success = true,
                        OptionalBoolean = false,
                        OptionalCount = _youtubeDbContext.Subscribers.Count(x => x.FollowedId == model.FollowedId)
                    };
                }
            }
            else
            {
                return new YoutubeApiResponse<Subscribers>
                {
                    Success = false,
                    Message = "Boş alan"
                };
            }
        }

        public YoutubeApiResponse<UserDTO> GetUserSubscribers(int id)
        {
            var user = _youtubeDbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                var userSubscribers = (from u in _youtubeDbContext.Users
                                       join s in _youtubeDbContext.Subscribers
                                       on u.Id equals s.FollowedId
                                       where s.FollowingId == id
                                       select new UserDTO
                                       {
                                           Id = u.Id,
                                           Name = u.Name,
                                           Image = u.Image,
                                           About = u.About,
                                       }).ToList();

                if (userSubscribers.Count > 0)
                {
                    return new YoutubeApiResponse<UserDTO>
                    {
                        Success = true,
                        DataList = userSubscribers
                    };
                }
                else
                {
                    return new YoutubeApiResponse<UserDTO>
                    {
                        Success = false,
                        Message = "Takip yok"
                    };
                }
            }
            else
            {
                return new YoutubeApiResponse<UserDTO>
                {
                    Success = false,
                    ErrorMessage = "Kullanıcı bulunamadı"
                };
            }
        }
    }
}
