using Application.Services;
using Domain.Mapper;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDependencies
    {

        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContratacaoService, ContratacaoService>();
            services.AddScoped<IPropostaService, PropostaService>();


            services.AddAutoMapper(x =>
            {
                x.AddProfile(new PropostaMapper());
            });
        }
    }
}
