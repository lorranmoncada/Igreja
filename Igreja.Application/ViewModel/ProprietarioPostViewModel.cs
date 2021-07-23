using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.ViewModel
{
   public class ProprietarioPostViewModel
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public Guid IdUserProprietario { get; set; }
        public DateTime DataCadastro { get; set; }
        public int QtdComentario { get; set; }
    }
}
