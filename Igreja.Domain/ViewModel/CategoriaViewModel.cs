using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.ViewModel
{
    public class CategoriaViewModel
    {
        public int Id { get; private set; }
        public string TipoCategoria { get; private set; }

        public CategoriaViewModel(int id, string tpCategoria)
        {
            Id = id;
            TipoCategoria = tpCategoria;
        }

        public CategoriaViewModel()
        {

        }
    }
}
