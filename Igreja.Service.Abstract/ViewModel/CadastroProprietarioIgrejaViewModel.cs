using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Service.Abstract.ViewModel
{
    public class CadastroProprietarioIgrejaViewModel
    {
        // cadastro
        public string Login { get; set; }
        public string Senha { get; set; }
        //Proprietario
        public string NomeProprietario { get; set; }
        public string CpfProrpietario { get; set; }
        //igreja
        public string NomeEnderecoIgreja { get; set; }
        public Guid IdTipoCategoria { get; set; }
        public string CepIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string CnpjIgreja { get; set; }
    }
}
