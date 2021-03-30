using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public interface IRepositoryGeneric<T> where T : BaseEntity
    {
        Task Add(T entity);

        Task Add(IEnumerable<T> items);

        void Update(T entity);

        void Update(IEnumerable<T> items);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        Task<IList<T>> All();

        Task<T> GetById(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
