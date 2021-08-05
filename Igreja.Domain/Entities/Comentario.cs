using Igreja.Core;
using Igreja.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public Guid IdUser { get; private set; }
        public Guid IdPost { get; private set; }
        public string ComentarioUsuario { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid? IdComentarioParent { get; private set; }

        //EF
        public virtual ProprietarioPost Post { get; private set; }
        public virtual Fiel Fiel { get; set; }

        //EF
        public Comentario() { }
        public Comentario(Guid idUser, string response, Guid idPost, Guid? idComentario)
        {
            IdUser = idUser;
            ComentarioUsuario = response;
            DataCadastro = DateTime.Now;
            IdPost = idPost;
            IdComentarioParent = idComentario;
        }
    }
}
