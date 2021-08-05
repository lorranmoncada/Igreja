using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;

namespace Igreja.Application.AutoMapper
{
    public class CadastroFielViewmodelMap: Profile
    {
        public CadastroFielViewmodelMap()
        {
            ViewModelLoginFielToViewModelLogin();
            ViewToLoginDomain();
            ViewToFiel();
        }

        public void ViewModelLoginFielToViewModelLogin()
        {
            CreateMap<CadastroFielViewModel, FielViewModel>();
        }

        public void ViewToLoginDomain()
        {
            CreateMap<FielViewModel, LoginFiel>().ConstructUsing(p => new LoginFiel(p.Login,p.Senha));
        }

        public void ViewToFiel()
        {
            CreateMap<FielViewModel, Fiel>().ConstructUsing(f => new Fiel(f.NomeFiel, f.Cpf, f.Telefone, f.Email, f.Cep, f.Endereco));
        }
    }
}
