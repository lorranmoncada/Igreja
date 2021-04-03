using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Service.Abstract.ViewModel
{
    public class FielViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NomeFiel { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public Guid IdIgreja { get; set; }
        public string Endereco { get; set; }

        public FielViewModel()
        {

        }
    } 
}
