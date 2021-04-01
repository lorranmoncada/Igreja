using Igreja.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroProprietarioAppService
{
    public interface ICadastroProprietarioAppService: IDisposable
    {
        Task<bool> CadastroUsuario(CadastroProprietarioViewModel cadastroProprietarioViewModel);
    }
}
