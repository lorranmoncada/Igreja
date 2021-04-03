using Igreja.Fieis.Service.Abastract.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Fieis.Service.Abastract
{
    public interface ICadastroFielService: IDisposable
    {
        Task CadastroFiel(FielViewModel cadastroFielViewModel);
    }
}
