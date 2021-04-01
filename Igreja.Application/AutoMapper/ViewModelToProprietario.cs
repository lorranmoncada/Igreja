using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Service.Abstract.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToProprietario : Profile
    {

        public ViewModelToProprietario()
        {
            MapearCadastroProprietarioDomainModel();
            MapearCadastroProprietarioViewModel();
        }

        private void MapearCadastroProprietarioDomainModel()
        {
            CreateMap<CadastroProprietarioViewModel, Proprietario>()
               .ConstructUsing(vw => new Proprietario(vw.NomeProprietario, vw.CpfProrpietario));
        }

        private void MapearCadastroProprietarioViewModel()
        {
            CreateMap<CadastroProprietarioIgrejaViewModel, Proprietario>()
               .ConstructUsing(vw => new Proprietario(vw.NomeProprietario, vw.CpfProrpietario));
        }

    }
}
