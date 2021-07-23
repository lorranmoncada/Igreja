using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Repositorie.Abastract
{
    public interface IComentarioRepository<T> where T: class
    {
        int QuantidadeComentarios(Guid idPost);

        Task<IList<T>> Comentarios(Guid idPost);
    }
}
