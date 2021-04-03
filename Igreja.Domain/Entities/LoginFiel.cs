using Igreja.Core;
using System;

namespace Igreja.Domain.Entity
{
    public class LoginFiel: BaseEntity
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        //EF
        public Fiel Fiel { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public LoginFiel(string login,string senha)
        {
            Login = login;
            Senha = senha;
            DataCadastro = DateTime.Now;
        }
    }
}
