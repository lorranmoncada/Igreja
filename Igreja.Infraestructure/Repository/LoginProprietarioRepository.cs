using Igreja.Core;
using Igreja.Domain.Entity;
using Igreja.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Repository
{
    public class LoginProprietarioRepository : RepositoryGeneric<LoginProprietario>, ILoginProprietarioRepository
    {
        public IgrejaContext _igrejaContext;
        public LoginProprietarioRepository(IgrejaContext igrejacontext) : base(igrejacontext)
        {
            _igrejaContext = igrejacontext;
        }
    }
}
