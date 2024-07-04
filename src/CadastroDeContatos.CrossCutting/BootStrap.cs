using CadastroDeContatos.Application.Interfaces;
using CadastroDeContatos.Application.Services;
using CadastroDeContatos.Data.Repositories;
using CadastroDeContatos.Domain.Interfaces;
using CadastroDeContatos.Domain.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeContatos.CrossCutting
{
    public static class BootStrap
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            AddApplicationSetup(services);
            AddDomainSetup(services);  
            AddAValidationSetup(services);

            return services;
        }

        private static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<IContatoService, ContatoService>();
        }

        private static void AddDomainSetup(this IServiceCollection services)
        {
            services
                .AddScoped<IContatoRepository, ContatoRepository>()
                .AddScoped<IDddRepository, DddRepository>();
        }

        private static void AddAValidationSetup(this IServiceCollection services)
        {
            services
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ContatoValidator>());
        }
    }
}
