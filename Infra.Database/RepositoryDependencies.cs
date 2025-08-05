using Domain.Repositories;
using Infra.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database
{
    public static class RepositoryDependencies
    {

        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();
        }
    }
}
