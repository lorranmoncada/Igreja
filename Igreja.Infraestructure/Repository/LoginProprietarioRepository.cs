using Igreja.Domain.Entity;
using Igreja.Repositorie.Abastract;

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
