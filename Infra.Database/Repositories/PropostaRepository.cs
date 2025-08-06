using Domain.Repositories;
using Infra.Database.Context;

namespace Infra.Database.Repositories
{
    public class PropostaRepository : RepositoryAsync<Domain.Entities.Proposta>, IPropostaRepository
    {
        public PropostaRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
