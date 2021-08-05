using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToEnderecoDomain : Profile
    {
        public ViewModelToEnderecoDomain()
        {
            CreateMap<CadastroProprietarioIgrejaViewModel, Endereco>()
               .ConstructUsing(vw => new Endereco(vw.NomeEnderecoIgreja, vw.CepIgreja));
        }
    }
}
