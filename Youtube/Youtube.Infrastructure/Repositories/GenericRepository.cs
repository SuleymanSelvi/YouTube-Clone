using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Youtube.Infrastructure.Repositories.Interfaces;

namespace Youtube.Infrastructure.Repositories
{
    public class GenericRepository<T> : IBaseRepository<T> where T : class
    {
        protected YoutubeDbContext _youtubeDbContext;

        public GenericRepository(YoutubeDbContext youtubeDbContext)
        {
            _youtubeDbContext = youtubeDbContext;
        }

        public T Add(T entity)
        {
            return _youtubeDbContext.Add(entity).Entity;
        }

        public IEnumerable<T> All()
        {
            return _youtubeDbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _youtubeDbContext.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _youtubeDbContext.Set<T>().FirstOrDefault(predicate);
        }

        public void SaveChanges()
        {
            _youtubeDbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            return _youtubeDbContext.Update(entity).Entity;
        }
    }
}
