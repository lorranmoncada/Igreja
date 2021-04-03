using AutoMapper;
using Igreja.Fieis.Domain.Entity;
using Igreja.Fieis.Domain.ViewModel;
using Igreja.Fieis.Service.Abastract.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Fieis.Application.AutoMapper
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
