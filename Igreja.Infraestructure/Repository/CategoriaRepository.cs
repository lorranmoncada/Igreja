using Igreja.Domain.Entity;
using Igreja.Repositorie.Abastract;


namespace Igreja.Infraestructure
{
    public class CategoriaRepository : RepositoryGeneric<CategoriaIgreja>, ICategoriaRepository
    {
        private readonly IgrejaContext _context;

        public CategoriaRepository(IgrejaContext context) : base(context)
        {
            _context = context;
        }
    }
}
