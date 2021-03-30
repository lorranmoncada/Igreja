using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class CategoriaIgreja : BaseEntity

    {
        public TipoCategoriaEnum TipoCategoria { get; private set; }
        // EF
        public virtual IList<IgrejaEntity> Igrejas {get;private set;}

        protected CategoriaIgreja()
        {
          
        }

        public CategoriaIgreja(TipoCategoriaEnum tipo)
        {
             TipoCategoria = tipo;
        }
    }
}
