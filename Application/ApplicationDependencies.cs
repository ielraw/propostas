using Application.Services;
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
            services.AddScoped<IContratacaoService, ContratacaoService>();
            services.AddScoped<IPropostaService, PropostaService>();
        }
    }
}
