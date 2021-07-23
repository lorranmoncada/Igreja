using Igreja.Application.ViewModel;
using Igreja.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroFielAppService
{
    public interface IFielAppService : IDisposable
    {
        Task CadastroFiel(CadastroFielViewModel cadastroFielViewModel);
        Task<IEnumerable<CristaoViewModel>> AllFieis();
    }
}
