
using Igreja.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Domain.Interface
{
    public interface ICadastroProprietarioServiceFacade: IDisposable
    {
        Task CadastratUsuarioProprietario(CadastroProprietarioIgrejaViewModel cadastroProprietarioIgrejaViewModel);
    }
}
