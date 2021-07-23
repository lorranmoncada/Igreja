using Igreja.Application.ViewModel;
using Igreja.Core.Util;
using Igreja.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.PostProprietario
{
    public interface IPostProprietarioAppService : IDisposable
    {
        Task CriarPost(ProprietarioPostViewModel post);
        //Task<IEnumerable<ProprietarioPost>> PostsByUser(Guid Id);
        Task<PagenateAux<ProprietarioPostViewModel>> PostsByByProprietario(PagedInfo info);
    }
}
