using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class Endereco : BaseEntity
    {
        public string NomeEndereco { get; private set; }
        public string Cep { get; private set; }
        //EF
        public virtual IList<IgrejaEntity> Igrejas {get;private set;}

        public Endereco(string nomeEndereco, string cep)
        {
            NomeEndereco = nomeEndereco;
            Cep = cep;
        }
    }
}
