using Igreja.Domain.ViewModel;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroProprietarioAppService
{
    public interface ICadastroProprietarioAppService
    {
        Task<bool> CadastroUsuario(CadastroProprietarioViewModel cadastroProprietarioViewModel);
    }
}
