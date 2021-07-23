using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Data;
using Igreja.Core.Util;
using Igreja.Domain.Dtos;
using Igreja.Domain.Entity;
using Igreja.Repositorie.Abastract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.PostProprietario
{
    public class PostProprietarioAppService : IPostProprietarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ProprietarioPost> _unitOfWorkProprietarioPost;
        private readonly IUnitOfWork<IgrejaEntity> _unitOfWorkIgrejaEntity;
        private readonly IPostProprietarioRepository<ProprietarioPost> _postProprietarioRepository;
        private readonly IComentarioRepository<DtoComentario> _comentarioRepository;
        private readonly IUnitOfWork<Proprietario> _unitOfWorkproprietarioRepository;

        public PostProprietarioAppService(IMapper mapper,
            IUnitOfWork<ProprietarioPost> unitOfWorkProprietarioPost,
            IPostProprietarioRepository<ProprietarioPost> postProprietarioRepository,
            IUnitOfWork<IgrejaEntity> unitOfWorkIgrejaEntity,
            IComentarioRepository<DtoComentario> comentarioRepository,
           IUnitOfWork<Proprietario> unitOfWorkproprietarioRepository)
        {
            _mapper = mapper;
            _unitOfWorkProprietarioPost = unitOfWorkProprietarioPost;
            _postProprietarioRepository = postProprietarioRepository;
            _unitOfWorkIgrejaEntity = unitOfWorkIgrejaEntity;
            _comentarioRepository = comentarioRepository;
            _unitOfWorkproprietarioRepository = unitOfWorkproprietarioRepository;
        }

        public async Task CriarPost(ProprietarioPostViewModel postagem)
        {
            var post = _mapper.Map<ProprietarioPost>(postagem);
            post.Post.Trim();
            await _unitOfWorkProprietarioPost.Repository.Add(post);
            await _unitOfWorkProprietarioPost.Commit();
        }

        public async Task<PagenateAux<ProprietarioPostViewModel>> PostsByByProprietario(PagedInfo info)
        {
            var igreja = await _unitOfWorkIgrejaEntity.Repository.GetById(info.Id);
            var proprietario = await _unitOfWorkproprietarioRepository.Repository.GetById(igreja.ProprietarioId);

            var posts = _postProprietarioRepository.PostsByUser(proprietario.IdUserProprietario);

            var paginatedListPost = await PaginatedList<ProprietarioPost>.CreateAsync(posts, info.Page, info.PageSize);

            var paginatedListPostViewModel = new PagenateAux<ProprietarioPostViewModel>(new List<ProprietarioPostViewModel>(), paginatedListPost.Itens.Count, paginatedListPost.PageIndex, paginatedListPost.PageSize);

            foreach (var post in paginatedListPost.Itens)
            {
                var postView = _mapper.Map<ProprietarioPostViewModel>(post);
                postView.QtdComentario = _comentarioRepository.QuantidadeComentarios(post.Id);
                paginatedListPostViewModel.Itens.Add(postView);
            }

            paginatedListPostViewModel.PageIndex = paginatedListPost.PageIndex;
            paginatedListPostViewModel.PageSize = paginatedListPost.PageSize;
            paginatedListPostViewModel.HasNextPage = paginatedListPost.HasNextPage;
            paginatedListPostViewModel.HasPreviousPage = paginatedListPost.HasPreviousPage;
            paginatedListPostViewModel.TotalPages = paginatedListPost.TotalPages;

            return paginatedListPostViewModel;
        }

        public void Dispose()
        {
            _unitOfWorkProprietarioPost?.Dispose();
        }
    }
}
