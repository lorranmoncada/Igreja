using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
    {
        private readonly IgrejaContext _igrejaContext;
        public UnitOfWork(IgrejaContext igrejaContext)
        {
            _igrejaContext = igrejaContext;
            Repository = new RepositoryGeneric<T>(_igrejaContext);
        }

        public IRepositoryGeneric<T> Repository { get; }

        public async Task<bool> Commit()
        {
           return await  _igrejaContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _igrejaContext?.Dispose();
        }
    }
}
