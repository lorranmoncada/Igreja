using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class LoginProprietario : BaseEntity
    {
        public string Login {get;private set;}
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Proprietario Proprietario { get; private set; }

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
