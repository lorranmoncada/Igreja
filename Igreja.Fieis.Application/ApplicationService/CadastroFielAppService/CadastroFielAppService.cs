using AutoMapper;
using Igreja.Core.Data;
using Igreja.Fieis.Domain.Entity;
using Igreja.Fieis.Domain.ViewModel;
using Igreja.Fieis.Service.Abastract;
using Igreja.Fieis.Service.Abastract.ViewModel;
using Ingreja.Fieis.Infraestructure;
using System;
using System.Threading.Tasks;

namespace Igreja.Fieis.Application.ApplicationService.CadastroFielAppService
{
    public class CadastroFielAppService : ICadastrofielAppService
    {
        private readonly IUnitOfWork<Fiel> _fielIunitOfWork;

        private readonly ICadastroFielService _cadastroService;

        private readonly IMapper _mapper;
        public CadastroFielAppService(IMapper mapper,IUnitOfWork<Fiel> fielIunitOfWork, ICadastroFielService cadastroService)
        {
            _fielIunitOfWork = fielIunitOfWork;
            _cadastroService = cadastroService;
            _mapper = mapper;


        }
        public async Task<bool> CadastroFiel(CadastroFielViewModel cadastroFielViewModel)
        {
            if (cadastroFielViewModel.EhValido())
            {
                var fiel = _mapper.Map<FielViewModel>(cadastroFielViewModel);

                await _cadastroService.CadastroFiel(fiel);

                return await _fielIunitOfWork.Commit();
            }

            return true;

        }

        public void Dispose()
        {
            _fielIunitOfWork?.Dispose();
        }
    }
}
