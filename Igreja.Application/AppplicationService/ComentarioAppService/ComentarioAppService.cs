using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Data;
using Igreja.Core.Util;
using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using Igreja.Domain.Entity;
using Igreja.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.Comentario
{
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Domain.Entities.Comentario> _genericComentario;
        IComentarioRepository _comentarioRepository;

        public ComentarioAppService(IMapper mapper,
            IUnitOfWork<Domain.Entities.Comentario> unitOfWorComentario,
              IComentarioRepository comentarioRepository)
        {
            _mapper = mapper;
            _genericComentario = unitOfWorComentario;
            _comentarioRepository = comentarioRepository;
        }

        public async Task<IList<DtoComentario>> Comentarios(Guid idPost)
        {
            return await _comentarioRepository.Comentarios(idPost);
        }

        public async Task<PaginatedList<ComentarioViewModel>> Respostas(Guid idComentario)
        {
            var comentarios = await PaginatedList<Domain.Entities.Comentario>.CreateAsync(_genericComentario.Repository.Where(x => x.IdComentarioParent == idComentario), 1, 3);
            return _mapper.Map<PaginatedList<Domain.Entities.Comentario>, PaginatedList<ComentarioViewModel>>(comentarios);
        }

        public async Task CriarComentario(ComentarioViewModel resposta)
        {
            var comentario = _mapper.Map<Domain.Entities.Comentario>(resposta);

            await _genericComentario.Repository.Add(comentario);
            await _genericComentario.Commit();
        }

        public void Dispose()
        {
            _genericComentario?.Dispose();
        }
    }
}
