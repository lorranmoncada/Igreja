using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelIgrejaToDomain: Profile
    {
        public ViewModelIgrejaToDomain()
        {
            CreateMap<CadastroProprietarioIgrejaViewModel, IgrejaEntity>()
               .ConstructUsing(vw => new IgrejaEntity(vw.NomeIgreja,vw.CnpjIgreja));
        }
    }
}
