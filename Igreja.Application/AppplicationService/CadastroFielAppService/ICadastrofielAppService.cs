using Igreja.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroFielAppService
{
    public interface ICadastrofielAppService:IDisposable
    {
        Task CadastroFiel(CadastroFielViewModel cadastroFielViewModel);
    }
}
