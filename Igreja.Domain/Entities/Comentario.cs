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
        public Guid? IdUserFielResponse { get; private set; }
        public Guid? IdUserPostResponse { get; private set; }
        public Guid IdPost { get; private set; }
        public string ComentarioUsuario { get; private set; }
        public DateTime DataCadastro { get; private set; }

        //EF
        public virtual ProprietarioPost Post { get; private set; }
        public virtual Fiel Fiel { get; set; }
        public virtual LoginProprietario Proprietario { get; set; }


        protected Comentario() { }
        public Comentario(Guid? idUserResponse, Guid? idUserFielPostResponse, string response, Guid idPost)
        {
            IdUserFielResponse = idUserFielPostResponse;
            IdUserPostResponse = idUserResponse;
            ComentarioUsuario = response;
            DataCadastro = DateTime.Now;
            IdPost = idPost;
        }
    }
}
