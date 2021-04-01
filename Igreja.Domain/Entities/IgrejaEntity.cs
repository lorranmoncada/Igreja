using Igreja.Core;
using System;

namespace Igreja.Domain.Entity
{
    public class IgrejaEntity : BaseEntity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid ProprietarioId { get; private set; }
        public virtual Proprietario Proprietario { get; private set; }
        public Guid CategoriaIgrejaId { get; private set; }
        public virtual CategoriaIgreja CategoriaIgreja { get; private set; }
        public Guid EnderecoId { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        public IgrejaEntity(string nome, string cnpj)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataCadastro = DateTime.Now;
        }

        public void AtribuirProprietario(Guid idProprietario) => ProprietarioId = idProprietario;
        public void AtribuirEndereco(Guid idEndereco) => EnderecoId = idEndereco;
        public void AtribuirCategoria(Guid tpCategoria) => CategoriaIgrejaId = tpCategoria;
    }
}

