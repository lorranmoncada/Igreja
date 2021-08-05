using Igreja.Core;
using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Interface
{
    public interface IComentarioRepository
    {
        int QuantidadeComentarios(Guid idPost);
        int QuantidadeRespostas(Guid idComentario);

        Task<IList<DtoComentario>> Comentarios(Guid idPost);

        //Task<IQueryable<Comentario>> Respostas(Guid idComentario);
    }
}
