using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain;

namespace Youtube.Infrastructure
{
    public class YoutubeDbContext : DbContext
    {
        public YoutubeDbContext(DbContextOptions<YoutubeDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<VideoLike> VideoLike { get; set; }
        public DbSet<VideoComments> VideoComments { get; set; }
        public DbSet<VideoCommentsLike> VideoCommentsLike { get; set; }
        public DbSet<VideoView> VideoView { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Shorts> Shorts { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<VideoSaved> VideoSaved { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<PlaylistVideos> PlaylistVideos { get; set; }
    }
}
