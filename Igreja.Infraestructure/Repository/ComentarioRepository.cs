using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using Igreja.Domain.ViewModel;
using Igreja.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Repository
{
    public class ComentarioRepository : RepositoryGeneric<Comentario>, IComentarioRepository
    {

        private readonly IgrejaContext _igrejaContext;

        public ComentarioRepository(IgrejaContext igrejaContext) : base(igrejaContext)
        {
            _igrejaContext = igrejaContext;
        }

        public async Task<IList<DtoComentario>> Comentarios(Guid idPost)
        {
            var list =  (from comentario in _igrejaContext.Comentario
                        join fiel in _igrejaContext.Fiel on comentario.IdUser equals fiel.Id into f
                        from fiel in f.DefaultIfEmpty()
                        where (comentario.IdPost == idPost && comentario.IdComentarioParent == null)

                        select new DtoComentario()
                        {
                            IdPost = comentario.IdPost,
                            IdUser = fiel.Id,
                            Comentario = comentario.ComentarioUsuario,
                            DataCadastro = comentario.DataCadastro,
                            NomeFiel = fiel.NomeFiel,
                            IdComentario = comentario.Id,
                            IdComentarioParent = comentario.IdComentarioParent,
                        }).AsEnumerable().Select(x => new DtoComentario()
                        {
                            IdPost = x.IdPost,
                            IdUser = x.IdUser,
                            Comentario = x.Comentario,
                            DataCadastro = x.DataCadastro,
                            NomeFiel = x.NomeFiel,
                            IdComentario = x.IdComentario,
                            IdComentarioParent = x.IdComentarioParent,
                            QtdComentario = QuantidadeRespostas((Guid)x.IdComentario)
                        }).ToList();


            return list;
        }

        public int QuantidadeRespostas(Guid idComentario)
        {
            return _igrejaContext.Comentario.AsNoTracking().Where(x => x.IdComentarioParent == idComentario).Count();
        }

        public int QuantidadeComentarios(Guid idPost)
        {
            return _igrejaContext.Comentario.Where(x => x.IdPost == idPost && x.IdComentarioParent == null).Count();
        }

        //public async Task<IQueryable<Comentario>> Respostas(Guid idComentario)
        //{
        //    return await _igrejaContext.Comentario.w;
        //}
    }
}
