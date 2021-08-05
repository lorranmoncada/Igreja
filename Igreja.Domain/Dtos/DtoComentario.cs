using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Dtos
{
    public class DtoComentario
    {
        public Guid? IdUser { get; set; }
        public Guid IdPost { get; set; }
        public Guid? IdComentario { get; set; }
        public string Comentario { get; set; }
        public int QtdComentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeFiel { get; set; }
        public Guid? IdComentarioParent { get; set; }
    }
}
