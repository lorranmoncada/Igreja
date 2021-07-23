using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AutoMapper
{
    public class FielDomainToFielViewModelMap : Profile
    {
        public FielDomainToFielViewModelMap()
        {
            FielDomainToFielViewModel();
        }

        private void FielDomainToFielViewModel()
        {
            CreateMap<Fiel, CristaoViewModel>()
            .ForMember(vm => vm.IdFiel, o => o.MapFrom(f => f.Id))
            .ForMember(vm => vm.IdIgreja, o => o.MapFrom(f => f.IdIgreja))
            .ForMember(vm => vm.NomeFiel, o => o.MapFrom(f => f.NomeFiel));
        }
    }
}
