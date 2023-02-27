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
    public class UsersRepository : GenericRepository<Users>
    {
        private YoutubeDbContext _youtubeDbContext;

        public UsersRepository(YoutubeDbContext youtubeDbContext) : base(youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public YoutubeApiResponse<Users> Login(LoginModel user)
        {
            //var decryptPassword = Convert.FromBase64String(user.Password);
            //var convertString = Encoding.UTF8.GetString(decryptPassword);

            var existUser = Get(x => x.Name == user.Name && x.Password == user.Password && x.IsActive == true);

            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password))
            {
                if (existUser != null)
                {
                    return new YoutubeApiResponse<Users>
                    {
                        Success = true,
                        Data = existUser
                    };
                }
                else
                {
                    return new YoutubeApiResponse<Users>
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı"
                    };
                }
            }
            else
            {
                return new YoutubeApiResponse<Users>
                {
                    Success = false,
                    Message = "Tüm alanları doldurunuz"
                };
            }
        }

        public YoutubeApiResponse<Users> Registir(RegistirModel user)
        {
            var existUser = Get(x => x.Name == user.Name);

            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.About))
            {
                if (existUser == null)
                {
                    var encryptPassword = Encoding.UTF8.GetBytes(user.Password);

                    var newUser = new Users()
                    {
                        Name = user.Name,
                        Image = "/Images/1.jpg",
                        Password = Convert.ToBase64String(encryptPassword),
                        About = user.About,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    Add(newUser);
                    SaveChanges();

                    return new YoutubeApiResponse<Users>
                    {
                        Success = true,
                        Data = newUser
                    };
                }
                else
                {
                    return new YoutubeApiResponse<Users>
                    {
                        Success = false,
                        Message = "Böyle bir kullanıcı bulunmaktadır"
                    };
                }
            }
            else
            {
                return new YoutubeApiResponse<Users>
                {
                    Success = false,
                    Message = "Tüm alanları doldurunuz"
                };
            }
        }

        public YoutubeApiResponse<UserDTO> GetUserDetail(string name, int sessionId)
        {
            if (name != null)
            {
                var user = Find(x => x.Name == name && x.IsActive == true).Select(x => new UserDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    About = x.About,
                    CreatedDate = x.CreatedDate,
                    CreatedDateAgo = Ultities.RelativeDate(x.CreatedDate),
                    ChannelSubscribersCount = _youtubeDbContext.Subscribers.Count(s => s.FollowedId == x.Id),
                    isSubscribers = _youtubeDbContext.Subscribers.Any(s => s.FollowedId == x.Id && s.FollowingId == sessionId),
                }).FirstOrDefault();

                return new YoutubeApiResponse<UserDTO>
                {
                    Success = true,
                    Data = user
                };
            }
            else
            {
                return new YoutubeApiResponse<UserDTO>
                {
                    Success = false,
                    Message = "Kullanıcı bulunamadı"
                };
            }
        }
    }
}
