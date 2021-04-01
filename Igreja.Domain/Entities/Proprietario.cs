using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class Proprietario : BaseEntity
    {
        public string NomeProprietario { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public virtual IList<IgrejaEntity> Igrejas { get; private set; }

        //EF
        public Guid IdUserProprietario { get; private set; }
        public virtual LoginProprietario LoginProprietario { get; private set; }


        public Proprietario(string nomeProprietario, string cpf)
        {
            NomeProprietario = nomeProprietario;
            Cpf = cpf;
            DataCadastro = DateTime.Now;
        }

        public void AtribuirIdLoginProprietario(Guid idLoginProprietario) => IdUserProprietario = idLoginProprietario;
    }
}
