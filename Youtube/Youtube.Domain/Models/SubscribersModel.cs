using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain.Models
{
    public class SubscribersModel
    {
        public int FollowedId { get; set; }
        public int FollowingId { get; set; }
    }
}
