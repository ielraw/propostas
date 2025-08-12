using Application.Services;
using Application.Validators;
using Domain.Mapper;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

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

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PropostaValidator>();

            services.AddScoped<IContratacaoService, ContratacaoService>();
            services.AddScoped<IPropostaService, PropostaService>();
        }
    }
}
