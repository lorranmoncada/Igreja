using Igreja.Core;
using Igreja.Domain.Entities;
using Igreja.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Entity
{
    public class ProprietarioPost : BaseEntity
    {
        public string Post { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdUserProprietario { get; set; }

        //EF
        public virtual IList<Comentario> Comentarios { get; set; }
        public virtual LoginProprietario LoginProprietario { get; set; }
}
}
