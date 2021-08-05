using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Util;
using Igreja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AutoMapper
{
    public class ComentarioViewModelToComentarioDomain : Profile
    {

        public ComentarioViewModelToComentarioDomain()
        {
            ViewModelToDomain();
            DomainToViewModel();
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PagedListConverter<,>));

            //CreateMap<Comentario, ComentarioViewModel>();
        }

        private void ViewModelToDomain()
        {
            CreateMap<ComentarioViewModel, Comentario>().ConstructUsing(vw =>
            new Comentario(vw.IdUser, vw.Comentario, vw.IdPost, vw.IdComentarioParent));
        }

        private void DomainToViewModel()
        {
            CreateMap<Comentario, ComentarioViewModel>()
            .ForMember(dest => dest.IdComentarioParent, o => o.MapFrom(src => src.IdComentarioParent))
            .ForMember(dest => dest.Comentario, o => o.MapFrom(src => src.ComentarioUsuario))
            .ForMember(dest => dest.IdPost, o => o.MapFrom(src => src.IdPost))
            .ForMember(dest => dest.IdUser, o => o.MapFrom(src => src.IdUser));
        }

        public class PagedListConverter<Comentario, ComentarioViewModel> : ITypeConverter<PaginatedList<Comentario>, PaginatedList<ComentarioViewModel>> where Comentario : class where ComentarioViewModel : class
        {
            public PaginatedList<ComentarioViewModel> Convert(PaginatedList<Comentario> source, PaginatedList<ComentarioViewModel> destination, ResolutionContext context)
            {
                var collection = context.Mapper.Map<List<Comentario>, List<ComentarioViewModel>>(source.Itens);

                return new PaginatedList<ComentarioViewModel>(collection, source.Itens.Count(), source.PageIndex, source.PageSize);
            }
        }


    }
}
