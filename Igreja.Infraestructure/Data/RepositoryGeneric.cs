using Igreja.Core;
using Igreja.Core.Data;
using Igreja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : BaseEntity
    {
        DbSet<T> Entity { get; set; }
        private readonly IgrejaContext _igrejaContext;
        public RepositoryGeneric(IgrejaContext igrejaContext)
        {
            Entity = igrejaContext.Set<T>();
            _igrejaContext = igrejaContext;
        }

        public async Task Add(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task Add(IEnumerable<T> items)
        {
            await Entity.AddRangeAsync(items);
        }

        public async Task<IEnumerable<T>> All()
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

        //public virtual void Dispose()
        //{
        //    _igrejaContext?.Dispose();
        //}

        public async Task<T> GetById(Guid id)
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
