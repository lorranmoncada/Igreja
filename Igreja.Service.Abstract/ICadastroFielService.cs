using Igreja.Service.Abstract.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Service.Abstract
{
    public interface ICadastroFielService: IDisposable
    {
        Task CadastroFiel(FielViewModel cadastroFielViewModel);
    }
}
