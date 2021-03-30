using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToLoginProprietario: Profile
    {

        public ViewModelToLoginProprietario()
        {
            MapearLoginProprietarioDomainModel();
        }

        private void MapearLoginProprietarioDomainModel()
        {
            CreateMap<CadastroProprietarioViewModel, LoginProprietario>()
               .ConstructUsing(vw => new LoginProprietario(vw.Login, vw.Senha));
        }
       

    }
}
