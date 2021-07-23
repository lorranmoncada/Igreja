using Igreja.Core.Data;
using Igreja.Core.DomainObjects;
using Igreja.Core.Extension;
using Igreja.Domain;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Application
{
    public class AplicationCategoriaIgrejaAppService : IAplicationCategoriaIgrejaAppService
    {
        private readonly IUnitOfWork<CategoriaIgreja> _categoriaUnitOfWork;
        public AplicationCategoriaIgrejaAppService(IUnitOfWork<CategoriaIgreja> categoriaRepository)
        {
            _categoriaUnitOfWork = categoriaRepository;
        }

        public async Task<IList<CategoriaViewModel>> ObterCategorias()
        {
            IList<CategoriaViewModel> CategoriaViewModel = new List<CategoriaViewModel>();
            var IgrejaCategorias = await _categoriaUnitOfWork.Repository.All();

            if (!IgrejaCategorias.Any())  throw new DomainException("Não foram encontradas categorias cadastradas");
            
            
            IgrejaCategorias.ForEachEnumerator(i => {
                foreach (var item in (TipoCategoriaEnum[])Enum.GetValues(typeof(TipoCategoriaEnum)))
                {
                    if (i.TipoCategoria == item)
                    {
                        CategoriaViewModel.Add(new CategoriaViewModel(i.Id, item.ToString()));
                    }
                }
            });

            return CategoriaViewModel;
        }
    }
}
