using Igreja.Application.ViewModel;
using Igreja.Core.Util;
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

        Task<PaginatedList<ComentarioViewModel>> Respostas(Guid idComentario);
    }
}
