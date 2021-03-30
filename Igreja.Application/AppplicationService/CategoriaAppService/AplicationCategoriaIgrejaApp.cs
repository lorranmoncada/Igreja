using Igreja.Core.Extension;
using Igreja.Domain;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Infraestructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application
{
    public class AplicationCategoriaIgrejaApp : IAplicationCategoriaIgrejaApp
    {
        private readonly IUnitOfWork<CategoriaIgreja> _categoriaUnitOfWork;
        public AplicationCategoriaIgrejaApp(IUnitOfWork<CategoriaIgreja> categoriaRepository)
        {
            _categoriaUnitOfWork = categoriaRepository;
        }

        public async Task<IList<CategoriaViewModel>> ObterCategorias()
        {
            IList<CategoriaViewModel> CategoriaViewModel = new List<CategoriaViewModel>();
            var IgrejaCategorias = await _categoriaUnitOfWork.Repository.All();
            
            IgrejaCategorias.ForEach(i => {
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
