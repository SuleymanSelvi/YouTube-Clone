using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public string CreatedDateAgo { get; set; }
        public int ChannelSubscribersCount { get; set; }
        public bool isSubscribers { get; set; }
    }
}
