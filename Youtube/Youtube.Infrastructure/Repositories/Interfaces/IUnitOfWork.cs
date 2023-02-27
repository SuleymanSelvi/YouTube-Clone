using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        UsersRepository UsersRepository { get; }
        VideosRepository VideosRepository { get; }
        VideosLikeRepository VideosLikeRepository { get; }
        VideosCommentsRepository VideosCommentsRepository { get; }
        VideosCommentsLikeRepository VideosCommentsLikeRepository { get; }
        SubscribersRepository SubscribersRepository { get; }
        VideosViewRepository VideosViewRepository { get; }
        CategoriesRepository CategoriesRepository { get; }
        ShortsRepository ShortsRepository { get; }
        VideoSavedRepository VideoSavedRepository { get; }
        PlaylistsRepository PlaylistsRepository { get; }
        PlaylistVideosRepository PlaylistVideosRepository { get; }
    }
}
