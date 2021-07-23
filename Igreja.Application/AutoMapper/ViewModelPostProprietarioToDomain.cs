using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Util;
using Igreja.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelPostProprietarioToDomain : Profile
    {
        public ViewModelPostProprietarioToDomain()
        {
            CreateMap<ProprietarioPostViewModel, ProprietarioPost>()
                .ForMember(p => p.DataCadastro, o => o.MapFrom(x => DateTime.Now))
                .ForMember(p => p.Post, o => o.MapFrom(x => x.Post))
                .ForMember(p => p.IdUserProprietario, o => o.MapFrom(x => x.IdUserProprietario));

            CreateMap<ProprietarioPost, ProprietarioPostViewModel>()
                .ForMember(p => p.Id, o => o.MapFrom(x => x.Id))
                .ForMember(p => p.DataCadastro, o => o.MapFrom(x => x.DataCadastro))
                .ForMember(p => p.Post, o => o.MapFrom(x => x.Post))
                .ForMember(p => p.IdUserProprietario, o => o.MapFrom(x => x.IdUserProprietario))
                .ForMember(p => p.QtdComentario, o => o.MapFrom(x => 0));
             }
    }
}
