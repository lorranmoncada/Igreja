using Igreja.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Events.FielEvents.CadastroEvent
{
    public class FielCadastradoEvent: Event
    {
        public FielCadastradoEvent(string email, string telefone, string nomeFiel)
        {
            Email = email;
            Telefone = telefone;
            NomeFiel = nomeFiel;
        }

        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string NomeFiel { get; private set; }
    }
}
