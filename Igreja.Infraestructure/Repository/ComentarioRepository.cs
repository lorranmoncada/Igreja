using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using Igreja.Domain.ViewModel;
using Igreja.Repositorie.Abastract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Repository
{
    public class ComentarioRepository : RepositoryGeneric<Comentario>, IComentarioRepository<DtoComentario>
    {

        private readonly IgrejaContext _igrejaContext;

        public ComentarioRepository(IgrejaContext igrejaContext) : base(igrejaContext)
        {
            _igrejaContext = igrejaContext;
        }

        public async Task<IList<DtoComentario>> Comentarios(Guid idPost)
        {
            var list = await (from comentario in _igrejaContext.PostResponse
                        join fiel in _igrejaContext.Fiel on comentario.IdUserFielResponse equals fiel.Id into f
                        from fiel in f.DefaultIfEmpty()
                        join proprietario in _igrejaContext.Proprietario on comentario.IdUserPostResponse equals proprietario.Id into p
                        from proprietario in p.DefaultIfEmpty()
                        where comentario.IdPost == idPost
                        select new DtoComentario()
                        {
                            IdPost = comentario.IdPost,
                            IdUserFielResponse = fiel.Id,
                            IdUserPostResponse = proprietario.Id,
                            Comentario = comentario.ComentarioUsuario,
                            DataCadastro = comentario.DataCadastro,
                            NomeFiel = fiel.NomeFiel
                        }).ToListAsync();


            return list;
        }

        public int QuantidadeComentarios(Guid idPost)
        {
            return _igrejaContext.PostResponse.Where(x => x.IdPost == idPost).Count();
        }
    }
}
