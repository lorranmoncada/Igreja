using Igreja.Core;
using Igreja.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : BaseEntity
    {
        DbSet<T> Entity { get; set; }
        public RepositoryGeneric(IgrejaContext igrejaContext)
        {
            Entity = igrejaContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task Add(IEnumerable<T> items)
        {
            await Entity.AddRangeAsync(items);
        }

        public async Task<IList<T>> All()
        {
           return await Entity.AsNoTracking().ToListAsync();
        }

        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }

        public  void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await Entity.SingleAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void Update(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return Entity.Where(expression);
        }
    }
}
