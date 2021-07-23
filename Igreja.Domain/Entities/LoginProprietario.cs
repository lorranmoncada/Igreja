using Igreja.Core;
using Igreja.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Igreja.Domain.Entity
{
    public class LoginProprietario : BaseEntity
    {
        public string Login {get;private set;}
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }

        //EF
        public Proprietario Proprietario { get; private set; }
        public virtual IList<ProprietarioPost> Posts { get; set; }
        public virtual IList<Comentario> Comentarios { get; set; }

        //EF
        protected LoginProprietario()
        {
       
        }

        public LoginProprietario(string login, string senha)
        {
            Login = login;
            Senha = senha;
            DataCadastro = DateTime.Now;
        }
    }
}
