using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToProprietario : Profile
    {

        public ViewModelToProprietario()
        {
            MapearCadastroProprietarioDomainModel();
        }

        private void MapearCadastroProprietarioDomainModel()
        {
            CreateMap<CadastroProprietarioViewModel, Proprietario>()
               .ConstructUsing(vw => new Proprietario(vw.NomeProprietario, vw.CpfProrpietario));
        }

    }
}
