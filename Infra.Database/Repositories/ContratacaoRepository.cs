using Domain.Repositories;
using Infra.Database.Context;

namespace Infra.Database.Repositories
{
    public class ContratacaoRepository : RepositoryAsync<Domain.Entities.Contratacao>, IContratacaoRepository
    {
        public ContratacaoRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
