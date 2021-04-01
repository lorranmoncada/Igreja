
using Igreja.Service.Abstract.ViewModel;
using System;
using System.Threading.Tasks;

namespace Igreja.Service.Abstract
{
    public interface ICadastroProprietarioServiceFacade: IDisposable
    {
        Task CadastratUsuarioProprietario(CadastroProprietarioIgrejaViewModel cadastroProprietarioIgrejaViewModel);
    }
}
