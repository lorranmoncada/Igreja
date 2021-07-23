using Igreja.Domain.Entity;
using Igreja.Repositorie.Abastract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Repository
{
   public class PostProprietarioRepository: RepositoryGeneric<ProprietarioPost>, IPostProprietarioRepository<ProprietarioPost>
    {
        public IgrejaContext _igrejaContext;
        public PostProprietarioRepository(IgrejaContext igrejacontext) : base(igrejacontext)
        {
            _igrejaContext = igrejacontext;
        }

        public IQueryable<ProprietarioPost> PostsByUser(Guid Id)
        {
            return _igrejaContext.ProprietarioPost.AsQueryable().Where(x => x.IdUserProprietario == Id);
        }
    }
}
