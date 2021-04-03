using Igreja.Fieis.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Fieis.Application.ApplicationService.CadastroFielAppService
{
    public interface ICadastrofielAppService:IDisposable
    {
        Task<bool> CadastroFiel(CadastroFielViewModel cadastroFielViewModel);
    }
}
