using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class Videos : BaseEntity
    {
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public string VideoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public int VideoDuration { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
