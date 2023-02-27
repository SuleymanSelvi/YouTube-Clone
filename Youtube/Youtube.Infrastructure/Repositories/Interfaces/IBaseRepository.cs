using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Add(T entity);

        T Update(T entity);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> All();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
