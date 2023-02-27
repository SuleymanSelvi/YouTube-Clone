using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YoutubeDbContext _youtubeDbContext;

        public UnitOfWork(YoutubeDbContext youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        private UsersRepository _usersRepository;
        public UsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(_youtubeDbContext);
                }

                return _usersRepository;
            }
        }


        private VideosRepository _videosRepository;
        public VideosRepository VideosRepository
        {
            get
            {
                if (_videosRepository == null)
                {
                    _videosRepository = new VideosRepository(_youtubeDbContext);
                }

                return _videosRepository;
            }
        }


        private VideosLikeRepository _videosLikeRepository;
        public VideosLikeRepository VideosLikeRepository
        {
            get
            {
                if (_videosLikeRepository == null)
                {
                    _videosLikeRepository = new VideosLikeRepository(_youtubeDbContext);
                }

                return _videosLikeRepository;
            }
        }


        private VideosCommentsRepository _videosCommentsRepository;
        public VideosCommentsRepository VideosCommentsRepository
        {
            get
            {
                if (_videosCommentsRepository == null)
                {
                    _videosCommentsRepository = new VideosCommentsRepository(_youtubeDbContext);
                }

                return _videosCommentsRepository;
            }
        }


        private VideosCommentsLikeRepository _videosCommentsLikeRepository;
        public VideosCommentsLikeRepository VideosCommentsLikeRepository
        {
            get
            {
                if (_videosCommentsLikeRepository == null)
                {
                    _videosCommentsLikeRepository = new VideosCommentsLikeRepository(_youtubeDbContext);
                }

                return _videosCommentsLikeRepository;
            }
        }


        private VideosViewRepository _videosViewRepository;
        public VideosViewRepository VideosViewRepository
        {
            get
            {
                if (_videosViewRepository == null)
                {
                    _videosViewRepository = new VideosViewRepository(_youtubeDbContext);
                }

                return _videosViewRepository;
            }
        }


        private CategoriesRepository _categoriesRepository;
        public CategoriesRepository CategoriesRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new CategoriesRepository(_youtubeDbContext);
                }

                return _categoriesRepository;
            }
        }


        private SubscribersRepository _subscribersRepository;
        public SubscribersRepository SubscribersRepository
        {
            get
            {
                if (_subscribersRepository == null)
                {
                    _subscribersRepository = new SubscribersRepository(_youtubeDbContext);
                }

                return _subscribersRepository;
            }
        }


        private ShortsRepository _shortsRepository;
        public ShortsRepository ShortsRepository
        {
            get
            {
                if (_shortsRepository == null)
                {
                    _shortsRepository = new ShortsRepository(_youtubeDbContext);
                }

                return _shortsRepository;
            }
        }

        private VideoSavedRepository _videoSavedRepository;
        public VideoSavedRepository VideoSavedRepository
        {
            get
            {
                if (_videoSavedRepository == null)
                {
                    _videoSavedRepository = new VideoSavedRepository(_youtubeDbContext);
                }

                return _videoSavedRepository;
            }
        }


        private PlaylistsRepository _playlistsRepository;
        public PlaylistsRepository PlaylistsRepository
        {
            get
            {
                if (_playlistsRepository == null)
                {
                    _playlistsRepository = new PlaylistsRepository(_youtubeDbContext);
                }

                return _playlistsRepository;
            }
        }


        private PlaylistVideosRepository _playlistVideosRepository;
        public PlaylistVideosRepository PlaylistVideosRepository
        {
            get
            {
                if (_playlistVideosRepository == null)
                {
                    _playlistVideosRepository = new PlaylistVideosRepository(_youtubeDbContext);
                }

                return _playlistVideosRepository;
            }
        }
    }
}
