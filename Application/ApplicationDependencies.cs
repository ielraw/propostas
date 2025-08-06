using Application.Services;
using Domain.Mapper;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationDependencies
    {

        public static void AddApplicationDependencies(this IServiceCollection services)
        {

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new PropostaMapper());
                x.AddProfile(new ContratacaoMapper());
            });

            services.AddScoped<IContratacaoService, ContratacaoService>();
            services.AddScoped<IPropostaService, PropostaService>();
        }
    }
}
