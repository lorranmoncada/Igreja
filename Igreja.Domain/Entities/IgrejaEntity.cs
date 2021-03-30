using Igreja.Core;
using System;

namespace Igreja.Domain.Entity
{
    public class IgrejaEntity : BaseEntity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int ProprietarioId { get; private set; }
        public virtual Proprietario Proprietario { get; private set; }
        public int CategoriaIgrejaId { get; private set; }
        public virtual CategoriaIgreja CategoriaIgreja { get; private set; }
        public int EnderecoId { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        public IgrejaEntity(string nome, string cnpj, int categoriaIgrejaId, int proprietarioId, int enderecoId)
        {
            Nome = nome;
            Cnpj = cnpj;
            CategoriaIgrejaId = categoriaIgrejaId;
            ProprietarioId = proprietarioId;
            EnderecoId = enderecoId;
            DataCadastro = DateTime.Now;
        }
    }
}

