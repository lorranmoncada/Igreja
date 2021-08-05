using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.ViewModel
{
    public class ComentarioViewModel
    {
        public Guid IdUser { get; set; }
        public Guid IdPost { get; set; }
        public string Comentario { get; set; }
        public int QtdComentario {get;set;}
        public Guid? IdComentarioParent { get; set; }
    }
}
