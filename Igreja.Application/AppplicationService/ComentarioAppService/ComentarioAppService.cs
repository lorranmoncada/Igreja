using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Data;
using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using Igreja.Domain.Entity;
using Igreja.Repositorie.Abastract;
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
        private readonly IUnitOfWork<Domain.Entities.Comentario> _unitOfWorComentario;
        IComentarioRepository<DtoComentario> _comentarioRepository;

        public ComentarioAppService(IMapper mapper,
            IUnitOfWork<Domain.Entities.Comentario> unitOfWorComentario,
              IComentarioRepository<DtoComentario> comentarioRepository)
        {
            _mapper = mapper;
            _unitOfWorComentario = unitOfWorComentario;
            _comentarioRepository = comentarioRepository;
        }

        public async Task<IList<DtoComentario>> Comentarios(Guid idPost)
        {
            return await _comentarioRepository.Comentarios(idPost);           
        }

        public async Task CriarComentario(ComentarioViewModel resposta)
        {
            var comentario = _mapper.Map<Domain.Entities.Comentario>(resposta);

            await _unitOfWorComentario.Repository.Add(comentario);
            await _unitOfWorComentario.Commit();
        }

        public void Dispose()
        {
            _unitOfWorComentario?.Dispose();
        }
    }
}
