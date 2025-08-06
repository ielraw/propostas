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
    public class ContratacaoRepository : RepositoryAsync<Domain.Entities.Contratacao>, IContratacaoRepository
    {
        public ContratacaoRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
