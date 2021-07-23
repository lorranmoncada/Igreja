using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.ProprietarioAppService
{
    public interface IProprietarioAppService: IDisposable
    {
        Task CadastroUsuario(CadastroProprietarioViewModel cadastroProprietarioViewModel);
        Task<IEnumerable<LoginProprietario>> Proprietarios();
    }
}
