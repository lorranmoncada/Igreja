using Igreja.Application.ViewModel;
using Igreja.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.Comentario
{
    public interface IComentarioAppService: IDisposable
    {
        Task CriarComentario(ComentarioViewModel comentario);

        Task<IList<DtoComentario>>Comentarios(Guid idPost);
    }
}
