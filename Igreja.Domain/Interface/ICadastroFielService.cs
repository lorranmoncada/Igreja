using Igreja.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Domain.Interface
{
    public interface ICadastroFielService: IDisposable
    {
        Task CadastroFiel(FielViewModel cadastroFielViewModel);
    }
}
