using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;

namespace AgendaSis.Infra.Repositorios
{
    public class PessoaFisicaRepository : GenericRepository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(MeuContexto dbContext) : base(dbContext)
        {
        }
    }
}
