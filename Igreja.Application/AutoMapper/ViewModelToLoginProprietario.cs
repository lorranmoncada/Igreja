using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Service.Abstract.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToLoginProprietario: Profile
    {

        public ViewModelToLoginProprietario()
        {
            MapearLoginProprietarioDomainModel();
            MapearLoginProprietarioViewModel();
        }

        private void MapearLoginProprietarioDomainModel()
        {
            CreateMap<CadastroProprietarioViewModel, LoginProprietario>()
               .ConstructUsing(vw => new LoginProprietario(vw.Login, vw.Senha));

            CreateMap<CadastroProprietarioIgrejaViewModel, LoginProprietario>()
               .ConstructUsing(vw => new LoginProprietario(vw.Login, vw.Senha));
        }

        private void MapearLoginProprietarioViewModel()
        {
            CreateMap<CadastroProprietarioViewModel, CadastroProprietarioIgrejaViewModel>();
                //.ForMember(des => des.IdTipoCategoria, o => o.MapFrom(o => o.IdTipoCategoria));
             
        }


    }
}
