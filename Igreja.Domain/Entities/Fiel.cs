using Igreja.Core;
using Igreja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class Fiel : BaseEntity
    {
        public string NomeFiel { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public Guid IdIgreja { get; private set; }
        public Guid IdLoginFiel { get; private set; }

        //EF
        public virtual IList<Comentario> ComentariosPost { get; private set; }

        public virtual LoginFiel LoginFiel { get; private set; }
        public virtual IgrejaEntity Igreja { get; private set; }
        public DateTime DataCadastro { get; private set; }


        public Fiel(string nomeFiel, string cpf, string telefone, string email, string cep, string endereco)
        {
            NomeFiel = nomeFiel;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Cep = cep;
            Endereco = endereco;
            DataCadastro = DateTime.Now;
        }

        public void AtribuirIdIgreja(Guid idIgreja) => IdIgreja = idIgreja;

        public void AtribuirLoginFiel(Guid idLoginFIel) => IdLoginFiel = idLoginFIel;
    }
}
