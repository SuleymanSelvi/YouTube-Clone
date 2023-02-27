﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class VideoCommentsLike : BaseEntity
    {
        [Required, ForeignKey("VideoComments")]
        public int VideoId { get; set; }

        [Required, ForeignKey("Users")]
        public int UserId { get; set; }

        [Required]
        public int LikeType { get; set; }
    }
}
