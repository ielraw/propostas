using Domain.Repositories;
using Infra.Database.Context;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database
{
    public static class DatabaseDependencies
    {

        public static void AddDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(conn, options =>
                {
                    options.MigrationsAssembly("Infra.Database");
                    options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                })
            );


            services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();


        }
    }
}
