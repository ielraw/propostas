using Domain.Repositories;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Repositories
{
    public class PropostaRepository : RepositoryAsync<Domain.Entities.Proposta>, IPropostaRepository
    {
        public PropostaRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
